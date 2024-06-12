﻿using ChineseOction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ChineseOction.DAL
{
    public class CartDal:ICartDal
    {
        private readonly ChinesesOctionContext chinesesOctionContext;

        public CartDal(ChinesesOctionContext chinesesOctionContext)
        {
            this.chinesesOctionContext = chinesesOctionContext;
        }
        public async Task<List<Cart>> GetCart(int userId)
        {
            try
            {
                var cart = await chinesesOctionContext.Carts.Include(g => g.Gift).Where(c=>c.UserId==userId).ToListAsync();
                if (cart.Count()!=0)
                {
                    return cart;
                }
                else
                {
                    throw (new Exception("There is no such user "));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public async Task<int> AddToCart(int userId,int giftId)
        {
            try 
            { 
                    var gift = await chinesesOctionContext.Carts.FirstOrDefaultAsync(g => g.UserId == userId &g.GiftId == giftId);
                        
                        if (gift != null)
                        {
                            gift.Quantity++;
                            await chinesesOctionContext.SaveChangesAsync();
                        
                        }
                        else
                        {
                            Cart cart = new Cart { GiftId = giftId, UserId = userId, Quantity = 1 };
                            await chinesesOctionContext.Carts.AddAsync(cart);
                            await chinesesOctionContext.SaveChangesAsync();
                        }
                        return giftId;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public async Task<int> RemoveFromCart(int userId, int giftId)
        {
            try
            {
                var gift = await chinesesOctionContext.Carts.FirstOrDefaultAsync(g => g.UserId == userId & g.GiftId == giftId);
                if (gift != null)
                {
                    chinesesOctionContext.Carts.Remove(gift);
                    await chinesesOctionContext.SaveChangesAsync();
                    return giftId;
                }
                else
                {
                    throw (new Exception("There is no such gift"));
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<int> Reduce(int userId, int giftId)
    {
        try
        {
            var gift = await chinesesOctionContext.Carts.FirstOrDefaultAsync(g => g.UserId == userId & g.GiftId == giftId);
               
            if (gift != null)
            {
                if (gift.Quantity == 1)
                {
                   chinesesOctionContext.Carts.Remove(gift);
                   await chinesesOctionContext.SaveChangesAsync();
                   return giftId;
                }
               
               gift.Quantity--;
               await chinesesOctionContext.SaveChangesAsync();
               return giftId;
            }
            else
            {
               throw (new Exception("There is no such gift"));
            }
           
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
        public async Task<int> Increas(int userId, int giftId)
        {

            try
            {
                
                var gift = await chinesesOctionContext.Carts.FirstOrDefaultAsync(g => g.UserId == userId & g.GiftId == giftId);
                if (gift != null)
                {
                    gift.Quantity++;
                    await chinesesOctionContext.SaveChangesAsync();
                    return giftId;
                }
                else
                {
                    throw (new Exception("no such gift"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
