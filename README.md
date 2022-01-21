![CI](../../workflows/CI/badge.svg)

BenchmarkDotNet=v0.13.1, OS=ubuntu 18.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|                      Method |      Mean |     Error |    StdDev | Ratio | RatioSD | Completed Work Items | Lock Contentions |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|---------------------------- |----------:|----------:|----------:|------:|--------:|---------------------:|-----------------:|---------:|---------:|---------:|----------:|
|  SystemTextJsonDeserializer | 11.478 ms | 0.1292 ms | 0.1209 ms |  1.00 |    0.00 |              28.7031 |           0.5781 |  78.1250 |  31.2500 |  15.6250 |     12 MB |
| JsonDocumentNonDeserializer | 14.790 ms | 0.2803 ms | 0.3000 ms |  1.29 |    0.03 |              26.6250 |           0.7813 |  78.1250 |  31.2500 |        - |     13 MB |
|       StreamNonDeserializer |  6.141 ms | 0.1221 ms | 0.2264 ms |  0.55 |    0.02 |              30.4453 |           0.6797 | 304.6875 | 273.4375 | 226.5625 |      9 MB |
