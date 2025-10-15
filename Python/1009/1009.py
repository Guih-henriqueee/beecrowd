funcionario = str(input()).upper
salario = float(input())
totalVendas = float(input())

salarioFinal = salario + (totalVendas * 0.15)

print(f'TOTAL = R$ {salarioFinal:.2f}')