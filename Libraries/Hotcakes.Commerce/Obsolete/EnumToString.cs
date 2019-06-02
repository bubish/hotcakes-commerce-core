#region License

// Distributed under the MIT License
// ============================================================
// Copyright (c) 2019 Hotcakes Commerce, LLC
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
// and associated documentation files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, publish, distribute, 
// sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or 
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
// THE SOFTWARE.

#endregion

using System;
using Hotcakes.Commerce.Orders;

namespace Hotcakes.Commerce.Utilities
{
    [Obsolete("Obsolete in 1.8.0. Use Hotcakes.Commerce.Globalization.LocalizationUtils class instead")]
    public class EnumToString
    {
        [Obsolete(
            "Obsolete in 1.8.0. Use Hotcakes.Commerce.Globalization.LocalizationUtils.GetOrderShippingStatus method instead"
            )]
        public static string OrderShippingStatus(OrderShippingStatus e)
        {
            var result = string.Empty;

            switch (e)
            {
                case Orders.OrderShippingStatus.FullyShipped:
                    result = "Shipped";
                    break;
                case Orders.OrderShippingStatus.NonShipping:
                    result = "Non Shipping";
                    break;
                case Orders.OrderShippingStatus.PartiallyShipped:
                    result = "Partially Shipped";
                    break;
                case Orders.OrderShippingStatus.Unknown:
                    result = "Unknown";
                    break;
                case Orders.OrderShippingStatus.Unshipped:
                    result = "Unshipped";
                    break;
            }

            return result;
        }

        [Obsolete(
            "Obsolete in 1.8.0. Use Hotcakes.Commerce.Globalization.LocalizationUtils.GetOrderPaymentStatus method instead"
            )]
        public static string OrderPaymentStatus(OrderPaymentStatus e)
        {
            var result = string.Empty;

            switch (e)
            {
                case Orders.OrderPaymentStatus.Overpaid:
                    result = "Overpaid";
                    break;
                case Orders.OrderPaymentStatus.Paid:
                    result = "Paid";
                    break;
                case Orders.OrderPaymentStatus.PartiallyPaid:
                    result = "Partially Paid";
                    break;
                case Orders.OrderPaymentStatus.Unknown:
                    result = "Unknown";
                    break;
                case Orders.OrderPaymentStatus.Unpaid:
                    result = "Unpaid";
                    break;
            }

            return result;
        }
    }
}