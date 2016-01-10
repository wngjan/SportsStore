using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using SportsStore.Models;

/// <summary>
/// Session 的摘要说明
/// </summary>
namespace SportsStore
{
    public enum SKEY
    {
        CART,
        RETURN_URL
    }
    public class SessionHelper
    {
        public SessionHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public static void Set(HttpSessionState session, SKEY key, object value)
        {
            session[Enum.GetName(typeof(SKEY), key)] = value;
        }

        public static object Get(HttpSessionState session, SKEY key)
        {
            return session[Enum.GetName(typeof(SKEY), key)];
        }

        public static Cart GetCart(HttpSessionState session)
        {
            Cart mycart = (Cart)Get(session, SKEY.CART);
            if (mycart == null) {
                mycart = new Cart();
                Set(session, SKEY.CART, mycart);
            }
            return mycart;
        }

    }
}