using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class COAGroupIdentificationRepository : GenericRepository<COAGroupIdentification>, ICOAGroupIdentificationRepository
    {
        private readonly EmbroDBContext dbCon;
        public COAGroupIdentificationRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<RResult> Create(List<COAGroupIdentification> groupIdentification, bool saveChanges)
        {
            try
            {

                RResult rResult = new();
                var categoryID = groupIdentification.First().GroupCategoryID;

                #region Old Code Frou List Insert And Update
                /*
                var dbData = await (
                              from g in dbCon.COAGroup
                              join gid in dbCon.COAGroupIdentification on new { g = g.GroupID, re = false, ac = true } equals
                                                                          new { g = gid.GroupID, re = gid.IsRemoved, ac = gid.IsActive }
                              where g.GroupCategoryID == categoryID && g.IsActive == true
                              select new COAGroupIdentification()
                              {
                                  GroupIdentificationID = gid.GroupIdentificationID,
                                  GroupID = gid.GroupID
                              }).ToListAsync();

                foreach (var id in dbData)
                {
                    var ignoreItem = await dbCon.COAGroupIgnoredItem
                                                .Where(b => b.GroupIdentificationID == id.GroupIdentificationID)
                                                .ToListAsync();
                    id.COAGroupIgnoredItem.AddRange(ignoreItem);
                }
                var getNewItem = groupIdentification.Where(b => b.GroupIdentificationID == 0).ToList();

                var getUpdateItem = groupIdentification.Where(b => b.GroupIdentificationID > 0).ToList();
                var getUpdatedIdList = getUpdateItem.Select(s => s.GroupIdentificationID).ToList();

                var deletedIdList = dbData
                             .Where(x => !getUpdatedIdList.Contains(x.GroupIdentificationID))
                             .Select(s => s.GroupIdentificationID)
                             .ToList();

                getUpdateItem = getUpdateItem.Where(ig => !deletedIdList.Contains(ig.GroupIdentificationID)).ToList();

                foreach (var item in getUpdateItem)
                {
                    var dbGroupIdentification = await dbCon.COAGroupIdentification
                            .Include(x => x.COAGroupIgnoredItem.Where(y => y.IsActive == true && y.IsRemoved == false))
                            .Where(x => x.GroupIdentificationID == item.GroupIdentificationID)
                            .FirstAsync();

                    dbGroupIdentification.GroupID = item.GroupID;

                    foreach (var itemIgnore in item.COAGroupIgnoredItem)
                    {
                        if (dbGroupIdentification.COAGroupIgnoredItem.Any(x => x.IgnoredItemID != itemIgnore.IgnoredItemID))
                        {
                            var dataObject = await dbCon.COAGroupIgnoredItem.FindAsync(itemIgnore.GroupIgnoredItemID);
                            dbCon.Remove(dataObject);
                       
                        }
                        else if (dbGroupIdentification.COAGroupIgnoredItem.Any(x => x.IgnoredItemID == itemIgnore.IgnoredItemID))
                        {
                            
                        }
                        else
                        {
                            dbGroupIdentification.COAGroupIgnoredItem.Add(itemIgnore);
                        }
                    }
                }


                //// Add New Item.
                if (getNewItem != null && getNewItem.Count > 0)
                {
                    await InsertAsync(getNewItem,false);
                }
                if(deletedIdList!=null && deletedIdList.Count > 0)
                {
                    foreach(var did in deletedIdList)
                    {
                        var deleteItem = await dbCon.COAGroupIdentification
                                          .Include(i => i.COAGroupIgnoredItem)
                                          .Where(b => b.GroupIdentificationID == did)
                                          .FirstAsync();
                        await DeleteAsync(deleteItem,false);
                         
                    }
                } 
                await dbCon.SaveChangesAsync();
                */
                #endregion

                var passingGrouIdentification = groupIdentification.First();
                if (passingGrouIdentification.GroupIdentificationID > 0 && passingGrouIdentification.GroupID > 0)
                {
                    var dbData = await dbCon.COAGroupIdentification
                        .Where(b => b.GroupIdentificationID == passingGrouIdentification.GroupIdentificationID && b.IsRemoved == false && b.IsActive == true)
                        .FirstOrDefaultAsync();
                    dbData.GroupID = passingGrouIdentification.GroupID;
                }
                else if (passingGrouIdentification.GroupIdentificationID > 0 && passingGrouIdentification.GroupID == 0)
                {
                    await DeleteAsync(passingGrouIdentification.GroupIdentificationID, false);
                }
                else if(passingGrouIdentification.GroupIdentificationID==0 
                        && passingGrouIdentification.IdentificationID>0 
                        && passingGrouIdentification.GroupID>0)
                {
                    dbCon.COAGroupIdentification.Add(passingGrouIdentification);
                }

                await dbCon.SaveChangesAsync();

                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
                return rResult;
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
