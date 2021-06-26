using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using ef_core_compare.Database;
using ef_core_compare.Entities;
using Microsoft.EntityFrameworkCore;

namespace ef_core_compare.Services
{
    [MemoryDiagnoser]
    public class UserProfileService
    {
        private DataContext _context;
        public int _quantity = 5000;

        public UserProfileService()
        {
            _context = new DataContext();
        }

        private UserProfile NewUser() => new UserProfile().FillData();

        [Benchmark]
        public void Add()
        {
            for (int i = 0; i < _quantity; i++)
            {
                _context.UserProfile.Add(NewUser());
            }

            _context.SaveChanges();
        }

        [Benchmark]
        public void ToList()
        {
            _context.UserProfile.ToList();
        }

        [Benchmark]
        public void ToArray()
        {
            _context.UserProfile.ToArray();
        }

        [Benchmark]
        public async Task ToListAsync()
        {
            await _context.UserProfile.ToListAsync();
        }

        [Benchmark]
        public void FirstOrDefault()
        {
            _context.UserProfile.FirstOrDefault();
        }

        [Benchmark]
        public async Task FirstOrDefaultAsync()
        {
            await _context.UserProfile.FirstOrDefaultAsync();
        }

        [Benchmark]
        public void Count()
        {
            _context.UserProfile.Count();
        }

        [Benchmark]
        public async Task CountAsync()
        {
            await _context.UserProfile.CountAsync();
        }

        [Benchmark]
        public async Task ToArrayAsync()
        {
            await _context.UserProfile.ToArrayAsync();
        }

        [Benchmark]
        public void Update()
        {
            foreach (var user in _context.UserProfile)
            {
                user.ChangeUser();
                _context.UserProfile.Update(user);
            }

            _context.SaveChanges();
        }

        [Benchmark]
        public void Remove()
        {
            foreach (var user in _context.UserProfile)
            {
                _context.UserProfile.Remove(user);
            }

            _context.SaveChanges();
        }

        [Benchmark]
        public void RemoveRange()
        {
            _context.UserProfile.RemoveRange(_context.UserProfile);
            _context.SaveChanges();
        }

        [Benchmark]
        public async Task AddAsync()
        {
            for (int i = 0; i < _quantity; i++)
            {
                await _context.UserProfile.AddAsync(NewUser());
            }

            await _context.SaveChangesAsync();
        }

        [Benchmark]
        public async Task AddRangeAsync()
        {
            var users = new List<UserProfile>();
            for (int i = 0; i < _quantity; i++)
            {
                users.Add(NewUser());
            }

            await _context.UserProfile.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }

        [Benchmark]
        public void BulkInsert()
        {
            var users = new List<UserProfile>();
            for (int i = 0; i < _quantity; i++)
            {
                users.Add(NewUser());
            }

            _context.BulkInsert(users);
        }

        [Benchmark]
        public void BulkUpdate()
        {
            foreach (var user in _context.UserProfile)
            {
                user.ChangeUser();
                _context.UserProfile.Update(user);
            }

            _context.BulkUpdate(_context.UserProfile);
        }

        [Benchmark]
        public void BulkDelete()
        {
            _context.BulkDelete(_context.UserProfile);
        }

        [Benchmark]
        public async Task BulkInsertAsync()
        {
            var users = new List<UserProfile>();
            for (int i = 0; i < _quantity; i++)
            {
                users.Add(NewUser());
            }

            await _context.BulkInsertAsync(users);
        }

        [Benchmark]
        public async Task BulkDeleteAsync()
        {
            await _context.BulkDeleteAsync(_context.UserProfile);
        }
    }
}
