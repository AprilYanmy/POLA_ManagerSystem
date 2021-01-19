using DAL;
using Model;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BLL
{
    public class Common
    {

        public static string MySQL_ConnectionTest()
        {
            return new MySQL_ConnectionTest().ConntectionTest();
        }

        /// <summary>处理DataTable中重复的数据。</summary>
        /// <param name="dt">需要处理的DataTable</param>
        /// <param name="colname">作为判断重复数据的字段(字段名)</param>
        /// <returns></returns>
        public static DataTable GetDistinctTable(DataTable dt, string colname)
        {
            DataView dv = dt.DefaultView;
            DataTable dtCardNo = dv.ToTable(true, colname);
            DataTable dtPoint = new DataTable();
            dtPoint = dv.ToTable();
            dtPoint.Clear();
            for (int i = 0; i < dtCardNo.Rows.Count; i++)
            {
                DataRow dr = dt.Select(colname + "='" + dtCardNo.Rows[i][0].ToString() + "'")[0];
                dtPoint.Rows.Add(dr.ItemArray);
            }
            return dtPoint;
        }

        /// <summary>为 DataGridView 添加行号。</summary>
        public static void ShowRows_DataGridView_RowPostPaint(DataGridView dgv, object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgv.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgv.RowHeadersDefaultCellStyle.Font, rectangle, dgv.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>验证会员信息是否正确</summary>
        /// <param name="memberid">会员卡号</param>
        /// <returns></returns>
        public static string ValidateMember(string memberid)
        {
            try
            {
                Member objMember = new MemberManager().LoadMemberInfo(memberid);
                return objMember.ID;
            }
            catch
            { }
            return "";
        }

        private static readonly object Locker = new object();
        private static int _sn = 0;

        /// <summary>
        /// 生成订单编号
        /// </summary>
        /// <returns></returns>
        public static string GetOrderID()
        {
            lock (Locker)  //lock 关键字可确保当一个线程位于代码的临界区时，另一个线程不会进入该临界区。
            {
                if (_sn == int.MaxValue)
                {
                    _sn = 0;
                }
                else
                {
                    _sn++;
                }

                Thread.Sleep(100);

                return DateTime.Now.ToString("yyyyMMddHHmmss") + _sn.ToString().PadLeft(6, '0');
            }
        }

        /// <summary>
        /// 数字输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="point"></param>
        public static void NumberAccpter(object sender, KeyPressEventArgs e, bool point)
        {
            int keyChar = e.KeyChar;
            if ((((keyChar >= 0x30) && (keyChar <= 0x39)) || (keyChar == 8)) || (keyChar == 0x2e))
            {
                if (!(point || (keyChar != 0x2e)))
                {
                    e.Handled = true;
                }
                else
                {
                    string text = "";
                    if ((sender != null) && (sender is TextBox))
                    {
                        text = ((TextBox)sender).Text;
                    }
                    if ((text == "") && (keyChar == 0x2e))
                    {
                        e.Handled = true;
                    }
                    else if ((text.IndexOf(".") >= 0) && (keyChar == 0x2e))
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 获取某年某月的天数
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public static int GetMonthMaxDay(int Year, int Month)
        {
            return DateTime.DaysInMonth(Year, Month);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <returns></returns>
        public static string EncryptMD5(string strData)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            // 将字符串转换成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(strData);
            // 调用加密方法
            byte[] byteNew = md5.ComputeHash(byteOld);

            return BitConverter.ToString(byteNew).Replace("-", "");
        }
    }
}
