![CI](../../workflows/CI/badge.svg)

BenchmarkDotNet=v0.13.1, OS=ubuntu 18.04
Intel Xeon Platinum 8272CL CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

|                      Method |     Mean |    Error |   StdDev | Ratio | RatioSD | Completed Work Items | Lock Contentions |    Gen 0 |   Gen 1 | Allocated |
|---------------------------- |---------:|---------:|---------:|------:|--------:|---------------------:|-----------------:|---------:|--------:|----------:|
|  SystemTextJsonDeserializer | 10.46 ms | 0.090 ms | 0.080 ms |  1.00 |    0.00 |              23.9531 |           0.6094 |  62.5000 | 15.6250 |     12 MB |
| JsonDocumentNonDeserializer | 15.04 ms | 0.242 ms | 0.227 ms |  1.44 |    0.03 |              25.8438 |           0.4219 |  78.1250 | 31.2500 |     13 MB |
|       StreamNonDeserializer | 10.73 ms | 0.129 ms | 0.120 ms |  1.03 |    0.02 |              36.1563 |           0.7031 | 218.7500 | 78.1250 |     13 MB |
