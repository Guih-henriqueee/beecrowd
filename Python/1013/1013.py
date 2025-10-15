values = input().split()
numero1 = int(values[0])
numero2 = int(values[1])
numero3 = int(values[2])

# Verifica qual é o maior número usando condicionais
if numero1 >= numero2 and numero1 >= numero3:
    maior = numero1
elif numero2 >= numero1 and numero2 >= numero3:
    maior = numero2
else:
    maior = numero3

# Exibe o resultado
print(f"{maior} eh o maior")