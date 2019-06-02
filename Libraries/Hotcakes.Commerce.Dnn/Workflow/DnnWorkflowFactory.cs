﻿#region License

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
using Hotcakes.Commerce.BusinessRules;
using Hotcakes.Commerce.BusinessRules.OrderTasks;

namespace Hotcakes.Commerce.Dnn.Workflow
{
    [Serializable]
    public class DnnWorkflowFactory : WorkflowFactory
    {
        protected override Task[] LoadPaymentCompleteTasks()
        {
            return new Task[]
            {
                new UpdateOrder(),
#pragma warning disable 0612, 0618
                new AvalaraCommitTaxes(),
#pragma warning restore 0612, 0618
                new TaxProviderCommitTaxes(),
                new UpdateOrder(),
                new EmailVATInvoice(),
                new IssueGiftCertificates(),
                new IssueRewardsPoints(),
                new RunAllDropShipWorkflows()
            };
        }

        protected override Task[] LoadProcessNewOrderTasks()
        {
            return new Task[]
            {
                new WorkflowNote("Starting Process Order Workflow"),
                new UpdateOrder(),
                new CheckForZeroDollarOrders(),
                new DnnCreateUserAccountForNewCustomer(),
                new AssignOrderToUser(),
                new AssignOrderNumber(),
                new MakeOrderAddressUsersCurrentAddress(),
                new AddUserAddressesToAddressBook(),
                new UpdateLineItemsForSave(),
                new UpdateOrder(),
                new DnnMakePlacedOrder(),
                new WorkflowNote("Finished Process Order Workflow"),
                new UpdateOrder()
            };
        }

        protected override Task[] LoadProcessNewOrderAfterPaymentsTasks()
        {
            return new Task[]
            {
                new WorkflowNote("Starting Order After Payment Workflow"),
                new UpdateOrder(),
                new LocalFraudCheck(),
                new MarkCompletedWhenShippedAndPaid(),
                new EmailOrder("Customer"),
                new EmailOrder("Admin"),
                new MembershipTask(),
                new WorkflowNote("Finished Order After Payment Workflow"),
                new UpdateOrder()
            };
        }
    }
}