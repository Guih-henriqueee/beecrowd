entrada = input()
entrada = entrada.split(' ')

varA = float(entrada[0])
varB = float(entrada[1])
varC = float(entrada[2])
delta = (varB ** 2) - (4 * varA * varC)


if varA == 0:
    print("Impossivel calcular")

elif delta > 0:
    baskara1 = ((-varB) + (delta ** 0.5)) / (2 * varA)
    baskara2 = ((-varB) - (delta ** 0.5)) / (2 * varA)
    print(f"R1 = {baskara1:.5f}")
    print(f"R2 = {baskara2:.5f}")

elif delta == 0:
    baskara1 = (-varB) / (2 * varA)
    print(f"R1 = {baskara1:.5f}")

else:
    print("Impossivel calcular")
