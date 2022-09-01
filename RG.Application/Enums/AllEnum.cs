using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Enums
{
    public enum enum_KnittingMachineNo
    {
        MachineNo = 444
    }
    public enum enum_KnittingDocumentType
    {
        RollCreation_JobConfirmation = 1,
        LabTest = 2,
        RollInspection = 3,
        JobIssuance = 4
    }
    public enum enum_LotGenerationDocumentType
    {
        Lot_Making = 2,
        Lot_Confirmation = 3,
        Lot_Inspection = 4,
        Lot_Issuance = 5
    }
    public enum enum_ServerType
    {
        MaxcoConnection = 1,
        MaterialsManagementConnection = 2,
        FiniteSchedulerConnection = 3,
        AOPConnection = 4,
        EMSConnection = 5,
        EmbroConnection = 7,

        AuthConnection = 11,
        Algo_HRM = 15
    }
    public enum enum_ApprovalNotificationStatus
    {
        Rejected = 0,
        Approved = 1,
        Processing = 2,
        Review = 3
    }
    public enum enum_MachineMaintenanceStatus
    {
        Rejected = 0,
        Approved = 1,
        Processing = 2
    }
    /// <summary>
    /// Login Device Type
    /// </summary>
    public enum enum_DeviceDependencyType
    {

        [Description("Device Independent")]
        DeviceIndependent = 1,

        [Description("Web Independent & Mobile Dependent")]
        WebIndependentAndMobileDependent = 2,

        [Description("Mobile Dependent")]
        MobileDependent = 3
    }
    public enum enum_FloorType
    {
        YarnStore = 1,
        Asset=2
    }
    

    #region HRMS
    public enum enum_AttendanceStatus:short
    {
        Holiday = 0,
        Weekday = 1,
        Absent = 2,
        Present = 3,
        [Description("Leave With Pay")]
        LeaveWithPay = 4,
        [Description("Leave Without Pay")]
        LeaveWithoutPay = 5,
        Default = 6,
        [Description("Half Day")]
        HalfDay = 7
    }
    #endregion
}
