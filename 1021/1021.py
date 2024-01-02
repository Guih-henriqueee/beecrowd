valor = float(input())

cedulas = [100, 50, 20, 10, 5, 2]
moedas = [1.00, 0.50, 0.25, 0.10, 0.05, 0.01]

print(f'NOTAS:')
for cedula in cedulas:
    quantidade_cedulas = int(valor // cedula)
    valor %= cedula  
    print(f'{quantidade_cedulas} nota(s) de R$ {cedula}.00')

print(f'MOEDAS:')
for moeda in moedas:
    quantidade_moedas = int(valor // moeda)
    valor %= moeda  
    print(f'{quantidade_moedas} moeda(s) de R$ {moeda:.2f}')
