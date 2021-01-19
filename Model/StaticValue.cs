using System.Collections.Generic;

namespace Model
{
    /// <summary>全局静态数据。</summary>
    public static class StaticValue
    {
        /// <summary>(全局变量)临时消费明细表。</summary>
        public static List<PayDetail> g_lstTempPayDetails;

        public static string g_strNewPayId = "";

        /// <summary>(全局变量)登陆用户身份</summary>
        public static string User_Type;

    }
}
