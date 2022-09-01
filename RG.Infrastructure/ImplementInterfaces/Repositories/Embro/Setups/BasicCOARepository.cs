using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.Embro.Setups.BasicCOAs.Queries.RequestResponseModel;
using RG.Application.Contracts.Embro.Setups.Levelss.Constants;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class BasicCOARepository : GenericRepository<BasicCOA>, IBasicCOARepository
    {
        private readonly EmbroDBContext dbCon;
        public BasicCOARepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        /*
        public async Task<List<BasicCOAViewModel>> CategoryWiseChartOfAccItems(decimal CompanyId, int CompanyWiseCategoryId, string ItemName = null)
        {
            List<BasicCOAViewModel> rMode = new List<BasicCOAViewModel>();
            try
            {
                ItemName = ItemName == null ? "" : ItemName;

                await dbCon.LoadStoredProc("ajt.CategoryWiseChartOf_Items")
                               .WithSqlParam("CompanyId", CompanyId)
                               .WithSqlParam("CompanyWiseCategoryId", CompanyWiseCategoryId)
                               .WithSqlParam("ItemName", ItemName)
                               .ExecuteStoredProcAsync((handler) =>
                               {
                                   rMode = handler.ReadToList<BasicCOAViewModel>() as List<BasicCOAViewModel>;
                               });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rMode;
        }
        public async Task<List<CommonAutocomplete>> CategoryWiseItem_AutoComplete(decimal CompanyId, int CompanyWiseCategoryId, string ItemName)
        {
            var autoList = await this.CategoryWiseChartOfAccItems(CompanyId, CompanyWiseCategoryId, ItemName);
            var rList = autoList
           .Select(b => new CommonAutocomplete()
           {
               InfoFieldId1 = b.AccountCode,
               AutoCompleteSelect = b.DESCRIPTION,
               AutoCompleteFocus = b.DESCRIPTION,
               InfoFieldId2 = b.LevelID.ToString(),
               ID = Convert.ToInt32(b.ID),
               Info = $"<b>{b.DESCRIPTION}</b> >>{b.DESCRIPTION}>>{b.NarrowGroup}>>{b.BroadGroup}>>{b.SubCategory}>>{b.Category}",
               InfoFieldId3 = b.ParentID.ToString()
           }).ToList();
            return rList;
        }
       */
        public async Task<List<SelectListItem>> DDLGetCompanyWiseKnitterList(int companyId)
        {
            /*
            List<SelectListItem> knitterListWithCompany = new List<SelectListItem>();
            var company = dbCon.CompanyInfo.Where(c => c.CompanyID == companyId).First();
            //knitterListWithCompany.Add(new SelectListItem { Text = company.Companyname, Value = company.CompanyID.ToString() });

            List<SelectListItem> knitterList = new List<SelectListItem>();
            try
            {
                List<int> headIdList = AccConfigaration.CompanyWiseKnitterAccHeadId(companyId).ToList();
                var accHead = string.Join(",", headIdList);

                await dbCon.LoadStoredProc("ajt.usp_GetYarnCommercialKnittersByCompany")
                .WithSqlParam("AccHead", accHead)
                .ExecuteStoredProcAsync((handler) =>
                {
                    knitterList = handler.ReadToList<SelectListItem>() as List<SelectListItem>;
                });
                knitterListWithCompany.AddRange(knitterList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            */
            return new List<SelectListItem>();
        }
        /*
        public async Task<List<CommonAutocomplete>> GetsSupplierListAutocomplete(string itemName, decimal companyId, string CategoryName = "")
        {
            List<CommonAutocomplete> supplierList = new List<CommonAutocomplete>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_ItemsLevelAutoComplete")
                .WithSqlParam("itemName", itemName)
                .WithSqlParam("companyId", companyId)
                .WithSqlParam("IsSupplier", 1)
                .WithSqlParam("CategoryName", CategoryName)
                .ExecuteStoredProcAsync((handler) =>
                {
                    supplierList = handler.ReadToList<CommonAutocomplete>() as List<CommonAutocomplete>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return supplierList;
        }
      */
        public async Task<List<SelectListItem>> /*DDLGetFinanceSupplierSetup*/ GetDDLCreditorsSupplior(int CompanyID = 0)
        {
            List<SelectListItem> SuppplierList = new List<SelectListItem>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_Finance_SupplierSetup_MM")
                .ExecuteStoredProcAsync((handler) =>
                {
                    SuppplierList = handler.ReadToList<SelectListItem>() as List<SelectListItem>;
                });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return SuppplierList;
        }
        public async Task<List<SelectListItem>> DDLGetCompanyWiseCostCenterList(int companyId)
        {
            var costCenterList = await (from bc in dbCon.BasicCOA
                                        join bc1 in dbCon.BasicCOA on bc.ParentID.Value equals bc1.ID
                                        where bc.LevelID == Con_AccLevels.CostCenter && bc1.ParentID == companyId
                                        select new SelectListItem
                                        {
                                            Text = bc.DESCRIPTION,
                                            Value = bc.ID.ToString()
                                        }).ToListAsync();
            return costCenterList;
        }
        public async Task<List<SelectListItem>> DDLGetCostcenterWiseLocationList(decimal costCenterId)
        {
            var costCenterLocationList = await (from cctr in dbCon.BasicCOA
                                                join ccl in dbCon.CostCenterLocation on cctr.ID equals ccl.CostCenterID
                                                join location in dbCon.BasicCOA on ccl.LocationID equals location.ID
                                                where cctr.ID == costCenterId && location.LevelID == Con_AccLevels.Location
                                                select new SelectListItem
                                                {
                                                    Text = location.DESCRIPTION,
                                                    Value = location.ID.ToString()
                                                }).ToListAsync();
            return costCenterLocationList;
        }
        public async Task<List<SelectListItem>> DDLGetCostcenterWiseActivityList(decimal costCenterId)
        {
            var costCenterActivityList = await (from cctr in dbCon.BasicCOA
                                                join activity in dbCon.BasicCOA on cctr.ID equals activity.ParentID.Value
                                                where cctr.ID == costCenterId && activity.LevelID == Con_AccLevels.Activity
                                                select new SelectListItem
                                                {
                                                    Text = activity.DESCRIPTION,
                                                    Value = activity.ID.ToString()
                                                }).ToListAsync();
            return costCenterActivityList;
        }

        public async Task<List<SelectListItem>> DDLChartOfAccounts(int? ParentID, int LevelID = 0, string Predict = null, CancellationToken cancellationToken = default)
        {

            var query = from bc in dbCon.BasicCOA
                        where bc.Status == 0
                        select new
                        {
                            ID = bc.ID,
                            Description = bc.DESCRIPTION,
                            LevelID = bc.LevelID,
                            ParentID = bc.ParentID
                        };
            if (LevelID > 0)
            {
                query = query.Where(b => b.LevelID == LevelID);
            }
            if (ParentID > 0)
            {
                query = query.Where(b => b.ParentID.Value == ParentID);
            }

            if (Predict != null && Predict.Length > 0)
            {
                query = query.Where(b => b.Description.Contains(Predict));
            } 
            var list = await query.Select(b => new SelectListItem
            {
                Text = b.Description,
                Value = b.ID.ToString()
            }).ToListAsync(cancellationToken);

            return list;

        }
        public async Task<List<SelectListItem>> DDLCompanyWiseChartOfAccounts(int ParentID, int LevelID = 0, string Predict = null, CancellationToken cancellationToken = default)
        {

            var query = from bc in dbCon.BasicCOA
                        join bcp in dbCon.BasicCOA on bc.ID equals bcp.ParentID.Value
                        join cc in dbCon.BasicCOA on bcp.ID equals cc.ParentID.Value
                        where bc.ID == ParentID && cc.DESCRIPTION.Trim() != "Not to Use"
                        select new
                        {
                            ID = cc.ID,
                            Description = cc.DESCRIPTION,
                            LevelID = cc.LevelID,
                            ParentID = cc.ParentID
                        };


            if (LevelID > 0)
            {
                query = query.Where(b => b.LevelID == LevelID);
            }
            

            if (Predict != null && Predict.Length > 0)
            {
                query = query.Where(b => b.Description.Contains(Predict));
            }
            var list = await query.Select(b => new SelectListItem
            {
                Text = b.Description,
                Value = b.ID.ToString()
            }).ToListAsync(cancellationToken);

            return list;

        }

        public async Task<List<SelectListItem>> DDLYarn_CommercialKnitters_Companywise(int CompanyID)
        {
            List<BasicCOA> supplierList = new List<BasicCOA>();
            try
            {
                await dbCon.LoadStoredProc("ajt.Yarn_CommercialKnitters_Companywise")
                .WithSqlParam("CompanyID", CompanyID)
                .ExecuteStoredProcAsync((handler) =>
                {
                    supplierList = handler.ReadToList<BasicCOA>() as List<BasicCOA>;
                });
                var ddlitem = supplierList.Select(b => new SelectListItem
                {
                    Text = b.DESCRIPTION,
                    Value = b.ID.ToString()
                }).ToList();
                return ddlitem;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            // return supplierList;
        }
        public async Task<BasicCOA> GetBasicCOAByID(decimal id, CancellationToken cancellationToken = default)
        {
            try
            {
                var data = await dbCon.BasicCOA.Where(x => x.ID == id).FirstAsync(cancellationToken);
                return data;
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public async Task<List<SelectListItem>> DDLGetReturnableNarrowGroup(int companyID, CancellationToken cancellationToken)
        {
            var data = await (from coa in dbCon.BasicCOA
                              join vp in dbCon.VoucherParameters on coa.ID equals vp.BusinessId.Value
                              join bcoa in dbCon.BasicCOA on vp.AccountId equals bcoa.ParentID
                              where coa.ParentID == companyID && coa.LevelID == 2 && vp.VoucherType == 4 && vp.Treatment == "Normal" && vp.EntryType == "Credit"
                              select new SelectListItem
                              {
                                  Text = bcoa.DESCRIPTION.Trim(),
                                  Value = bcoa.ID.ToString()
                              }).OrderBy(x => x.Text).ToListAsync();
            return data;
        }

        public async Task<List<BasicCOADetailRM>> GetBasicCOADetailInfo(int groupCategoryID, int companyID, string predict, CancellationToken cancellationToken = default)
        {
            var query = from cat in dbCon.BasicCOA
                        join sCat in dbCon.BasicCOA on new { categoryID = (int)cat.ID, Status = (byte)0 } equals new { categoryID = sCat.ParentID.Value, sCat.Status }
                        join brd in dbCon.BasicCOA on new { broadGroupID = (int)sCat.ID, Status = (byte)0 } equals new { broadGroupID = brd.ParentID.Value, brd.Status }
                        join narr in dbCon.BasicCOA on new { categoryID = (int)brd.ID, Status = (byte)0 } equals new { categoryID = narr.ParentID.Value, narr.Status }
                        join idn in dbCon.BasicCOA on new { categoryID = (int)narr.ID, Status = (byte)0 } equals new { categoryID = idn.ParentID.Value, idn.Status }
                        join itm in dbCon.BasicCOA on new { categoryID = (int)idn.ID, Status = (byte)0 } equals new { categoryID = itm.ParentID.Value, itm.Status }

                        join coaGI in dbCon.COAGroupIdentification on new { IdentificationID = (int)idn.ID } equals new { coaGI.IdentificationID } into lj
                        from lj1 in lj.DefaultIfEmpty()

                        join coaG in dbCon.COAGroup on new { lj1.GroupID, groupCategoryID } equals new { coaG.GroupID, groupCategoryID=coaG.GroupCategoryID } into lj6
                        from lj7 in lj6.DefaultIfEmpty()

                        join coaGII in dbCon.COAGroupIgnoredItem on new { lj1.GroupIdentificationID, lj1.IdentificationID, ItemID = (int)itm.ID } equals new { coaGII.GroupIdentificationID, coaGII.IdentificationID, ItemID = coaGII.IgnoredItemID } into lj2
                        from lj3 in lj2.DefaultIfEmpty()

                            //join coaGI2 in dbCon.COAGroupIdentification on new { IdentificationID = (int)idn.ID } equals new { coaGI2.IdentificationID } into lj4
                            //from lj5 in lj4.DefaultIfEmpty()


                        where cat.ParentID == companyID
                        select new BasicCOADetailRM
                        {
                            CategoryID = (int)cat.ID,
                            Category = cat.DESCRIPTION.Trim(),
                            SubCategoryID = (int)sCat.ID,
                            SubCategory = sCat.DESCRIPTION.Trim(),
                            BroadGroupID = (int)brd.ID,
                            BroadGroup = brd.DESCRIPTION.Trim(),
                            NarrowGroupID = (int)narr.ID,
                            NarrowGroup = narr.DESCRIPTION.Trim(),
                            IdentificationID = (int)idn.ID,
                            Identification = idn.DESCRIPTION.Trim(),
                            ItemID = (int)itm.ID,
                            Item = itm.DESCRIPTION.Trim(),
                            IsAssignedIdentification = lj1 != null,
                            GroupIdentificationID=lj1==null?0:lj1.GroupIdentificationID,
                            IsIgnoredItem = lj3 != null,
                            IdentificationAssignedCategoryID= lj7 == null ? 0 : lj7.GroupCategoryID,
                            IdentificationAssignedGroupID = lj7 == null ? "" :$"{lj7.GroupID}",
                            IdentificationAssignedGroup = lj7 == null ? "" : $"{lj7.GroupCode}. {lj7.GroupName}"
                        };
            if (predict != null)
            {
                query = query.Where(x => x.Identification.Contains(predict) || x.Item.Contains(predict));
            }
            var data = await query.OrderBy(x => x.CategoryID)
                                    .ThenBy(x => x.SubCategoryID)
                                    .ThenBy(x => x.BroadGroupID)
                                    .ThenBy(x => x.NarrowGroupID)
                                    .ThenBy(x => x.IdentificationID)
                                    .ThenBy(x => x.Item)
                            .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLChartOfAccounts(int CompanyID, int LevelID, string Category =null, string Predict = null, CancellationToken cancellationToken = default)
        {
            try
            {
                //categoryList = new List<string>();
                //var group = await query
                //               .Select(g => $"{g.DepartmentName}-{g.SectionName}")
                //               .Distinct()
                //               .Select(gn => new SelectListGroup() { Name = gn })
                //               .ToDictionaryAsync(gp => gp.Name, StringComparer.Ordinal, cancellationToken);
                //var dataValue = await query
                //                .Select(s => new SelectListItem()
                //                {
                //                    Text = $"{s.EMPCode} - {s.EmployeeName}",
                //                    Value = DPValue == "ID" ? s.EmployeeID.ToString() : s.EMPCode,
                //                    Group = group[$"{s.DepartmentName}-{s.SectionName}"]
                //                }).ToListAsync(cancellationToken);
                //return dataValue;

                var categoryList = ListToString.StringToIntList<string>(Category, ",");
                var query = from cat in dbCon.BasicCOA
                            join sub in dbCon.BasicCOA on (int)cat.ID equals sub.ParentID
                            join brd in dbCon.BasicCOA on (int)sub.ID equals brd.ParentID
                            join nrr in dbCon.BasicCOA on (int)brd.ID equals nrr.ParentID
                            join idn in dbCon.BasicCOA on (int)nrr.ID equals idn.ParentID
                            join itm in dbCon.BasicCOA on (int)idn.ID equals itm.ParentID
                            where cat.ParentID == CompanyID && (Category == null || categoryList.Contains(cat.DESCRIPTION))
                            && itm.Status == 0
                            orderby cat.ID, sub.ID, brd.ID, itm.DESCRIPTION
                            select new
                            {
                                CategoryID = (int)cat.ID,
                                Category = cat.DESCRIPTION,
                                LevelId4 = cat.LevelID,
                                SubCategoryId = (int)sub.ID,
                                SubCateogory = sub.DESCRIPTION,
                                LevelId5 = sub.LevelID,
                                BroadGroupId = (int)brd.ID,
                                BroadGroup = brd.DESCRIPTION,
                                LevelId6 = brd.LevelID,
                                NarrowId = (int)nrr.ID,
                                Narrow = nrr.DESCRIPTION,
                                LevelId7 = nrr.LevelID,
                                IdentificationId = (int)idn.ID,
                                Identification = idn.DESCRIPTION,
                                LevelId8 = idn.LevelID,
                                ItemId = (int)itm.ID,
                                Item = itm.DESCRIPTION,
                                LevelId14 = itm.LevelID
                            };

                if (!string.IsNullOrEmpty(Predict))
                {
                    query = query.Where(w => w.Item.Contains(Predict) || w.Identification.Contains(Predict));
                }
                
                query = query.OrderBy(o=>o.Item)
                    .Where(w => w.Item.Length > 0).Take(400);

                var group = await query
                               .Select(g => new { GroupName =$"{g.Category}<<{g.SubCateogory}<<{g.Identification}" })
                               .Distinct()
                               .Select(gn => new SelectListGroup() { Name = gn.GroupName })
                               .ToDictionaryAsync(gp => gp.Name, StringComparer.Ordinal, cancellationToken);

                var querysss = query.ToQueryString();

                var dataValue = await query
                                .Select(s => new SelectListItem()
                                {
                                    Text = $"{s.Item}",
                                    Value = s.ItemId.ToString(),
                                    Group = group[$"{s.Category}<<{s.SubCateogory}<<{s.Identification}"]
                                }).ToListAsync(cancellationToken);
                 
                return dataValue;
            }
            catch (Exception e)
            {

                throw new(e.Message);
            }
            
        }
        /*
public async Task<List<vw_ItemAccounts_OfCompany>> GetItemAccounts_OfCompany(int accountId, int companyId)
{
var list = await dbCon.vw_ItemAccounts_OfCompany.Where(x => x.CompanyID == companyId && x.AccountID == accountId).ToListAsync();

return list;
}
*/
    }
}
