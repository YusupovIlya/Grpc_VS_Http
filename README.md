### Результаты работы:

## Тесты gRPC (клиент и сервер на одной и той же машине)

``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2728/21H2/November2021Update)
AMD Ryzen 3 2200U with Radeon Vega Mobile Gfx, 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.302
  [Host]     : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT AVX2


```
|          Method |     Mean |   Error |  StdDev |    Gen0 | Allocated |
|---------------- |---------:|--------:|--------:|--------:|----------:|
|   GetUserByGrpc | 520.1 μs | 5.82 μs | 4.86 μs |  1.9531 |   7.29 KB |
|  GetArrayByGrpc | 555.8 μs | 4.52 μs | 3.77 μs |  7.8125 |  15.38 KB |
| GetBigObjByGrpc | 761.2 μs | 4.43 μs | 4.14 μs | 30.2734 |  62.79 KB |


## Тесты Http (клиент и сервер на одной и той же машине)

|          Method |     Mean |   Error |  StdDev |    Gen0 | Allocated |
|---------------- |---------:|--------:|--------:|--------:|----------:|
|   GetUserByRest | 200.1 μs | 0.59 μs | 0.49 μs |  0.9766 |   2.88 KB |
|  GetArrayByRest | 228.1 μs | 2.03 μs | 1.70 μs |  2.4414 |   4.91 KB |
| GetBigObjByRest | 333.8 μs | 2.01 μs | 1.68 μs | 14.6484 |  30.41 KB |

<hr/>

## Результаты запуска сервера на виртуалке

### запрос на http:
<p align="center"><img src="https://github.com/YusupovIlya/Grpc_VS_Http/blob/master/ScreenShots/1.jpg"></p>

### запрос на gRPC:
<p align="center"><img src="https://github.com/YusupovIlya/Grpc_VS_Http/blob/master/ScreenShots/2.jpg"></p>

## Тесты gRPC (клиент на пк, сервер на виртуалке + пишутся логи)

|          Method |     Mean |     Error |    StdDev |    Gen0 | Allocated |
|---------------- |---------:|----------:|----------:|--------:|----------:|
|   GetUserByGrpc | 2.440 ms | 0.0268 ms | 0.0237 ms |       - |   6.96 KB |
|  GetArrayByGrpc | 2.319 ms | 0.0447 ms | 0.0496 ms |  7.8125 |  15.04 KB |
| GetBigObjByGrpc | 2.678 ms | 0.0501 ms | 0.0536 ms | 27.3438 |  62.47 KB |

## Тесты Http (клиент на пк, сервер на виртуалке + пишутся логи)

|          Method |     Mean |     Error |    StdDev |    Gen0 | Allocated |
|---------------- |---------:|----------:|----------:|--------:|----------:|
|   GetUserByRest | 1.989 ms | 0.0356 ms | 0.0500 ms |       - |   2.51 KB |
|  GetArrayByRest | 1.985 ms | 0.0368 ms | 0.0673 ms |       - |   4.55 KB |
| GetBigObjByRest | 2.168 ms | 0.0433 ms | 0.0361 ms | 11.7188 |   30.1 KB |
