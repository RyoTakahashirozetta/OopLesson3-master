using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace SendMailApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    /// 
    public partial class MainWindow : Window {

        SmtpClient sc = new SmtpClient();

        public MainWindow() {
            InitializeComponent();
            sc.SendCompleted += Sc_SendCompleted;
        }

        //メール送信が完了したとき
        private void Sc_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            if (e.Cancelled) {
                MessageBox.Show("送信はキャンセルされました");
            }
            else {
                MessageBox.Show(e.Error?.Message　?? "送信完了です!");
            }
        }

        //メール送信処理
        private void btOK_Click(object sender, RoutedEventArgs e) {
            try {
                Config cf = Config.GetInstance();
                MailMessage msg = new MailMessage(cf.MailAddress,tbTo.Text);

                for (int i = 0; i < lbtmp.Items.Count; i++) {
                    Attachment attachment = new System.Net.Mail.Attachment(lbtmp.Items[i].ToString());
                    msg.Attachments.Add(attachment);
                }
                

                if (tbCc.Text != "") {
                    msg.CC.Add(tbCc.Text);
                }
                if (tbBcc.Text != "") {
                    msg.Bcc.Add(tbBcc.Text);
                }

                msg.Subject = tbTitle.Text; //件名
                msg.Body = tbBody.Text; //本文


                sc.Host = cf.Smtp;//SMTPサーバーの設定
                sc.Port = cf.Port;
                sc.EnableSsl = cf.Ssl;
                sc.Credentials = new NetworkCredential(cf.MailAddress, cf.PassWord);

                sc.SendAsync(msg, msg);//送信
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        //キャンセル処理
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            if (sc != null)
                sc.SendAsyncCancel();
        }

        //設定ボタンイベントハンドラ
        private void btConfig_Click(object sender, RoutedEventArgs e) {
            ConfigWindowShow();//表示
        }
        //設定画面表示
        private static void ConfigWindowShow() {
            ConfigWindow configWindow = new ConfigWindow();//設定画面のインスタンスを生成
            configWindow.ShowDialog();//表示
        }

        //メインウィンドウがロードされるタイミングで呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            try {
                Config.GetInstance().DeSerislise();

            }
            catch (FileNotFoundException) {
                //btConfig_Click(sender, e)
                ConfigWindowShow();
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void Window_Closed(object sender, EventArgs e) {
            try {
                Config.GetInstance().Serialise();
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
           
        }


        private void btDeletetmp_Click(object sender, RoutedEventArgs e) {
            lbtmp.Items.RemoveAt(lbtmp.SelectedIndex);
        }

        private void btAddtmp_Click(object sender, RoutedEventArgs e) {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = @"C:\";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "すべてのファイル(*.*)|*.*";
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
           

            //ダイアログを表示する
            if (ofd.ShowDialog() == true) {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                lbtmp.Items.Add(ofd.FileName);
            }
        }
    }
}
