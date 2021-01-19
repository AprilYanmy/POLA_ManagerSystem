using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class MemberManager
    {
        /// <summary>
        /// 加载会员信息
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public Member LoadMemberInfo(string mid)
        {
            return new Table_Member().SelectMemberInfo(mid);
        }

        #region 自定义函数...

        /// <summary>检查是否存在相同会员卡号，返回空字符串时为不存在。</summary>
        /// <param name="mid">会员卡号</param>
        /// <returns></returns>
        public string ExistsMemberCard(string mid)
        {
            int ID = new Table_Member().CheckMemberID(mid);
            if (ID > 0)
            {
                return ID.ToString();
            }
            return "";
        }

        /// <summary>查询会员信息。</summary>
        /// <param name="membertext">会员卡号或姓名</param>
        /// <param name="enabled">显示不可用会员</param>
        /// <returns></returns>
        public List<Member> SelectList(string membertext, bool enabled)
        {
            return new Table_Member().SelectAllMemberInfo(membertext, enabled);
        }


        /// <summary>获取会员总数量</summary>
        /// <param name="mode">查询方式(0可用，1不可用，2全部)</param>
        /// <param name="cid">会员卡类型(0所有)</param>
        /// <returns></returns>
        public int GetMemberTotal(int mode, int cid)
        {
            return new Table_Member().GetMembersCount(mode, cid);
        }

        /// <summary>新增会员信息。</summary>
        /// <returns></returns>
        public int InsertMember(Member member)
        {
            return new Table_Member().AddMember(member);
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public int DeleteMember(int mid)
        {
            return new Table_Member().DelMember(mid);
        }

        /// <summary>编辑会员信息。</summary>
        /// <returns></returns>
        public int UpdateMember(Member member)
        {
            return new Table_Member().UpdateMember(member);
        }

        public int UpdateMemberID(Member member,string oldid)
        {
            return new Table_Member().UpdateMemberID(member,oldid);
        }

        /// <summary>更新会员状态(退卡)。</summary>
        /// <returns></returns>
        public int UpdateStatus(string ID, string Remark)
        {
            return new Table_Member().UpdateStatus(ID, Remark);
        }

        /// <summary>会员换卡</summary>
        /// <param name="oldmember">旧会员卡信息</param>
        /// <param name="newid">新卡号</param>
        /// <returns></returns>
        public bool UpdateExchange(Member oldmember, string newid)
        {
            return new Table_Member().UpdateExchange(oldmember, newid);
        }

        /// <summary>
        /// 会员转账
        /// </summary>
        /// <param name="from_mid"></param>
        /// <param name="to_mid"></param>
        /// <param name="balance"></param>
        /// <returns>0:更新成功;1:转账账户更新失败;2:接收账户更新失败</returns>
        public int TransferBalance(string from_mid, string to_mid, decimal balance)
        {
            return new Table_Member().TransferBalance(from_mid, to_mid, balance);
        }

        /// <summary>更新会员余额。</summary>
        /// <param name="memberid">会员卡号</param>
        public void UpdateBalance(string memberid)
        {
            new Table_Member().UpdateBalance(memberid);
        }

        public int UpdateLastTime(string memberid, DateTime lasttime)
        {
            return new Table_Member().UpdateLastTime(memberid, lasttime);
        }

        /// <summary>
        /// 获取最近一次充值
        /// </summary>
        /// <returns></returns>
        public string LastDeposit(string ID)
        {
            return new Table_Member().LastDeposit(ID);
        }

        #endregion
    }
}
