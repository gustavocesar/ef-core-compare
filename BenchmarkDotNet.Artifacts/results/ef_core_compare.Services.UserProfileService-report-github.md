``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.1052 (2004/May2020Update/20H1)
Intel Core i7-3517U CPU 1.90GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.203
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  DefaultJob : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT


```
|              Method |         Mean |     Error |    StdDev |       Median |       Gen 0 |      Gen 1 | Gen 2 |    Allocated |
|-------------------- |-------------:|----------:|----------:|-------------:|------------:|-----------:|------:|-------------:|
|                 Add |    59.464 ms |  5.818 ms | 16.787 ms |    60.791 ms |   2000.0000 |          - |     - |     6,761 KB |
|              ToList |    16.719 ms |  2.938 ms |  8.092 ms |    14.710 ms |           - |          - |     - |       334 KB |
|             ToArray |    15.619 ms |  1.772 ms |  4.909 ms |    14.543 ms |           - |          - |     - |       327 KB |
|         ToListAsync |    31.060 ms |  2.430 ms |  6.612 ms |    29.743 ms |   1000.0000 |          - |     - |     2,319 KB |
|      FirstOrDefault |    12.438 ms |  4.906 ms | 14.154 ms |     4.245 ms |           - |          - |     - |         9 KB |
| FirstOrDefaultAsync |    14.187 ms |  4.316 ms | 12.244 ms |    10.320 ms |           - |          - |     - |        13 KB |
|               Count |     6.060 ms |  1.679 ms |  4.789 ms |     4.695 ms |           - |          - |     - |         6 KB |
|          CountAsync |     5.246 ms |  1.279 ms |  3.670 ms |     3.881 ms |           - |          - |     - |        10 KB |
|        ToArrayAsync |    36.888 ms |  3.771 ms | 10.879 ms |    33.575 ms |   1000.0000 |          - |     - |     2,327 KB |
|              Update | 1,674.619 ms | 31.134 ms | 62.892 ms | 1,653.152 ms | 266000.0000 | 30000.0000 |     - |   599,481 KB |
|              Remove |     4.411 ms |  1.029 ms |  2.869 ms |     3.517 ms |           - |          - |     - |         7 KB |
|         RemoveRange |     5.463 ms |  2.109 ms |  5.913 ms |     3.192 ms |           - |          - |     - |         7 KB |
|            AddAsync |    44.431 ms |  2.707 ms |  7.811 ms |    43.201 ms |   3000.0000 |          - |     - |     7,066 KB |
|       AddRangeAsync |    40.291 ms |  2.216 ms |  6.286 ms |    38.837 ms |   3000.0000 |          - |     - |     7,455 KB |
|          BulkInsert |    42.999 ms |  8.822 ms | 25.453 ms |    33.662 ms |   2000.0000 |          - |     - |     5,965 KB |
|          BulkUpdate | 4,400.233 ms | 71.127 ms | 66.532 ms | 4,389.609 ms | 839000.0000 | 87000.0000 |     - | 1,824,987 KB |
|          BulkDelete |     9.080 ms |  2.452 ms |  7.035 ms |     6.783 ms |           - |          - |     - |         7 KB |
|     BulkInsertAsync |    27.116 ms |  2.167 ms |  6.041 ms |    26.942 ms |   2000.0000 |          - |     - |     5,331 KB |
|     BulkDeleteAsync |     7.232 ms |  1.698 ms |  4.900 ms |     6.759 ms |           - |          - |     - |         8 KB |
