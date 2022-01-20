![CI](../../workflows/CI/badge.svg)

|                        Method |      Mean |     Error |    StdDev | Ratio | RatioSD |
|------------------------------ |----------:|----------:|----------:|------:|--------:|
|                       RawText |  2.043 ms | 0.0737 ms | 0.2174 ms |  0.38 |    0.05 |
|               RawTextValidate | 20.451 ms | 0.4056 ms | 0.6664 ms |  3.89 |    0.36 |
|                JsonDocumenter |  2.374 ms | 0.0507 ms | 0.1486 ms |  0.44 |    0.04 |
|        JsonDocumenterValidate |  2.818 ms | 0.0558 ms | 0.1101 ms |  0.53 |    0.04 |
|         JsonDocumenterRawText |  4.540 ms | 0.1185 ms | 0.3437 ms |  0.84 |    0.09 |
| JsonDocumenterRawTextValidate |  4.550 ms | 0.1094 ms | 0.3208 ms |  0.84 |    0.08 |
|              JsonDeserializer |  5.473 ms | 0.1246 ms | 0.3675 ms |  1.00 |    0.00 |
|      JsonDeserializerValidate | 24.514 ms | 0.4748 ms | 0.7107 ms |  4.65 |    0.49 |
