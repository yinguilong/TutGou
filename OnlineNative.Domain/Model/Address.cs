/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.0
 *命名空间：OnlineNative.Domain.Model
 *文件名：  Address
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：7/7/2015 3:03:49 PM
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：7/7/2015 3:03:49 PM
 *修改人：  yinguilong
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Domain.Model
{
    public class Address
    {

        #region Properties
        // 国家
        public string Country { get; set; }

        //省份
        public string State { get; set; }

        // 市
        public string City { get; set; }

        public string Street { get; set; }

        public string Zip { get; set; }
        #endregion

        #region Object Member
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            Address another = obj as Address;
            if (another == null)
                return false;

            return this.Country.Equals(another.Country) &&
                this.State.Equals(another.State) &&
                this.City.Equals(another.City) &&
                this.Street.Equals(another.Street) &&
                this.Zip.Equals(another.Zip);
        }

        public override int GetHashCode()
        {
            return this.Country.GetHashCode() ^
                this.State.GetHashCode() ^
                this.City.GetHashCode() ^
                this.Street.GetHashCode() ^
                this.Zip.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, {2}, {3}, {4}", Zip, Street, City, State, Country);
        }
        #endregion

        #region Public Static Operator Overrides

        public static bool operator ==(Address a, Address b)
        {
            if (a == null)
            {
                return b == null;
            }
            return a.Equals(b);
        }

        public static bool operator !=(Address a, Address b)
        {
            return !(a == b);
        }
        #endregion
    }
}
