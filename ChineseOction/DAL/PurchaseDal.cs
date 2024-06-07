using ChineseOction.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ChineseOction.DAL
{
    public class PurchaseDal : IPurchaseDal
    {
        private readonly ChinesesOctionContext chinesesOctionContext;

        public PurchaseDal(ChinesesOctionContext chinesesOctionContext)
        {
            this.chinesesOctionContext = chinesesOctionContext;
        }
        public async Task<List<PurchaseList>> GetPurchaseByGift(int giftId)
        {
            try
            {
                var purchase = await chinesesOctionContext.PurchaseLists.Include(g=>g.Gift).Include(p=>p.Purchase).ThenInclude(c=>c.Customer)
                                    .Where(g => g.GiftId == giftId).ToListAsync();
                return purchase;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<List<PurchaseList>> SortByMaxPrice()
        {
            try
            {
                var purchase = await chinesesOctionContext.PurchaseLists
                                    .Include(g => g.Gift)
                                    .OrderByDescending(g => g.Gift.Price)
                                    .ToListAsync();
                return purchase;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<List<PurchaseList>> SortByMostPurchasedGift()
        {
            try
            {
                //var purchase = await chinesesOctionContext.PurchaseLists
                //                    .OrderByDescending(g => g.sum(g.Quantity))
                //                    .ToListAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<List<User>> GetDetails()
        {
            try
            {
                var purchase = await chinesesOctionContext.Purchases
                                    .Include(p => p.Customer)
                                    .Select(u => u.Customer)
                                    .Distinct()
                                    .ToListAsync();
                return purchase;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
