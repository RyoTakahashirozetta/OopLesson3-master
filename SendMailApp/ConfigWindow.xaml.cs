using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace SendMailApp {
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window {
        public ConfigWindow() {
            InitializeComponent();
            tbPassWord.PasswordChanged += anythingChanged;
            tbPort.TextChanged += anythingChanged;
            tbSender.TextChanged += anythingChanged;
            tbSmtp.TextChanged += anythingChanged;
            tbUserName.TextChanged += anythingChanged;

        }

        

        private void btDefault_Click(object sender, RoutedEventArgs e) {
            Config cf = (Config.GetInstance()).getDefaultStatus();
            //Config defaultData = cf.getDefaultStatus();

            tbSmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbSender.Text= tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;
        }

        //適用（更新）
        private void btApply_Click(object sender, RoutedEventArgs e) {
            try {
                if (tbPassWord.Password == "" || tbSender.Text == "" || tbPort.Text == "" ||
                tbSmtp.Text == "" || tbUserName.Text == "") {
                    MessageBox.Show("未入力の項目があります");
                }


            (Config.GetInstance()).UpdataStatus(
            tbSmtp.Text,
            tbUserName.Text,
            tbPassWord.Password,
            int.Parse(tbPort.Text),
            cbSsl.IsChecked ?? false);
            }
            catch (Exception) {
            }

            count = 5;
     

        }

        //OKボタン
        private void btOk_Click(object sender, RoutedEventArgs e) {
            try {
                if (tbPassWord.Password == "" || tbSender.Text == "" || tbPort.Text == "" ||
                tbSmtp.Text == "" || tbUserName.Text == "") {
                    MessageBox.Show("未入力の項目があります");
                }
                else {
                    btApply_Click(sender, e);
                    this.Close();
                }
            }
            catch (Exception) {
                MessageBox.Show("保存できません");
            }
            
                    
            

        }

        //キャンセルボタン
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            TextBoxChange();

        }

       

        //ロード時に一度だけ呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if (true) {

            }
            Config cf = Config.GetInstance();

            tbSmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbSender.Text = tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;

        }

        bool change = false;
        int count = 0;

        private void anythingChanged<T>(object sender, T e) where T : EventArgs {
            change = true;
            count++;
        }

        private void TextBoxChange() {
            if (count > 5) {
                MessageBoxResult result = MessageBox.Show("変更が反映されていません", "メッセージボックス", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK) {
                    this.Close();
                }
                else if (result == MessageBoxResult.Cancel) {

                }

            }
            else {
                this.Close();
            }
        }



    }
}
