﻿using asp_mvc_sample_with_course_udemi.Data;
using asp_mvc_sample_with_course_udemi.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_mvc_sample_with_course_udemi.Services
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext _context;

        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteItem(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

            _context.Items.Remove(item);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetById(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveItem(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
