using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using ef_core_compare.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ef_core_compare
{
    public class Worker : BackgroundService
    {
        private readonly UserProfileService _service = new UserProfileService();
        private readonly Stopwatch _sw = new Stopwatch();
        
        public Worker(ILogger<Worker> logger)
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // BenchmarkRunner.Run<UserProfileService>();

            Console.Clear();
            Log($" {_service._quantity} Records of Tests");

            await CreateMethods();
            await RetrieveMethods();
            await UpdateMethods();
            await DeleteMethods();
            
            Log(" Finish!");
        }

        private async Task RetrieveMethods()
        {
            ReloadData();

            Log($"");
            Log($" ---- Retrieve Methods ----");

            _sw.Restart();
            _service.ToList();
            _sw.Stop();
            Log($"  ToList() - {_sw.ElapsedMilliseconds} ms");

            ReloadData();

            _sw.Restart();
            _service.ToArray();
            _sw.Stop();
            Log($"  ToArray() - {_sw.ElapsedMilliseconds} ms");

            ReloadData();

            _sw.Restart();
            await _service.ToListAsync();
            _sw.Stop();
            Log($"  ToListAsync() - {_sw.ElapsedMilliseconds} ms");

            ReloadData();

            _sw.Restart();
            await _service.ToArrayAsync();
            _sw.Stop();
            Log($"  ToArrayAsync() - {_sw.ElapsedMilliseconds} ms");

            ReloadData();

            _sw.Restart();
            _service.FirstOrDefault();
            _sw.Stop();
            Log($"  FirstOrDefault() - {_sw.ElapsedMilliseconds} ms");

            ReloadData();

            _sw.Restart();
            await _service.FirstOrDefaultAsync();
            _sw.Stop();
            Log($"  FirstOrDefaultAsync() - {_sw.ElapsedMilliseconds} ms");

            ReloadData();

            _sw.Restart();
            _service.Count();
            _sw.Stop();
            Log($"  Count() - {_sw.ElapsedMilliseconds} ms");

            ReloadData();

            _sw.Restart();
            await _service.CountAsync();
            _sw.Stop();
            Log($"  CountAsync() - {_sw.ElapsedMilliseconds} ms");
        }

        private async Task CreateMethods()
        {
            ClearData();

            Log($"");
            Log($" ---- Add Methods ----");

            _sw.Restart();
            _service.Add();
            _sw.Stop();
            Log($"  Add() - {_sw.ElapsedMilliseconds} ms");

            ClearData();

            _sw.Restart();
            await _service.AddAsync();
            _sw.Stop();
            Log($"  AddAsync() - {_sw.ElapsedMilliseconds} ms");

            ClearData();

            _sw.Restart();
            await _service.AddRangeAsync();
            _sw.Stop();
            Log($"  AddRangeAsync() - {_sw.ElapsedMilliseconds} ms");

            ClearData();

            _sw.Restart();
            _service.BulkInsert();
            _sw.Stop();
            Log($"  BulkInsert() - {_sw.ElapsedMilliseconds} ms");

            ClearData();

            _sw.Restart();
            await _service.BulkInsertAsync();
            _sw.Stop();
            Log($"  BulkInsertAsync() - {_sw.ElapsedMilliseconds} ms");
        }

        private async Task UpdateMethods()
        {
            ReloadData();

            Log($"");
            Log($" ---- Update Methods ----");

            _sw.Restart();
            _service.Update();
            _sw.Stop();
            Log($"  Update() - {_sw.ElapsedMilliseconds} ms");

            ReloadData();

            _sw.Restart();
            _service.BulkUpdate();
            _sw.Stop();
            Log($"  BulkUpdate() - {_sw.ElapsedMilliseconds} ms");
        }

        private async Task DeleteMethods()
        {
            ReloadData();

            Log($"");
            Log($" ---- Delete Methods ----");

            _sw.Restart();
            _service.Remove();
            _sw.Stop();
            Log($"  Remove() - {_sw.ElapsedMilliseconds} ms");

            ReloadData();

            _sw.Restart();
            _service.RemoveRange();
            _sw.Stop();
            Log($"  RemoveRange() - {_sw.ElapsedMilliseconds} ms");

            ReloadData();

            _sw.Restart();
            _service.BulkDelete();
            _sw.Stop();
            Log($"  BulkDelete() - {_sw.ElapsedMilliseconds} ms");

            ReloadData();

            _sw.Restart();
            await _service.BulkDeleteAsync();
            _sw.Stop();
            Log($"  BulkDeleteAsync() - {_sw.ElapsedMilliseconds} ms");
        }

        private void ClearData()
        {
            _service.RemoveRange();
        }

        private void LoadData()
        {
            _service.Add();
        }

        private void ReloadData()
        {
            ClearData();
            LoadData();
        }

        private void Log(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
