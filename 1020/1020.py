entrada = int(input())

Anos = entrada // 365
entrada %= 365
Meses = entrada // 30
Dias = entrada % 30


print(f'{Anos} ano(s)\n{Meses} mes(es)\n{Dias} dia(s)')
