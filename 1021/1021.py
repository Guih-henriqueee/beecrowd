# Função para calcular a quantidade mínima de notas e moedas
def calcular_notas_moedas(valor):
    # Lista de cédulas e moedas disponíveis
    cedulas = [100, 50, 20, 10, 5, 2]
    moedas = [1, 0.5, 0.25, 0.10, 0.05, 0.01]

    print("NOTAS:")

    # Calcular e imprimir notas
    for cedula in cedulas:
        quantidade_cedulas = int(valor / cedula)
        valor %= cedula
        print(f"{quantidade_cedulas} nota(s) de R$ {cedula}.00")

    print("MOEDAS:")

    # Calcular e imprimir moedas
    for moeda in moedas:
        quantidade_moedas = int(valor / moeda)
        valor = round(valor % moeda, 2)
        print(f"{quantidade_moedas} moeda(s) de R$ {moeda:.2f}")


# Ler o valor da entrada
valor = float(input())

# Chamar a função com o valor lido
calcular_notas_moedas(valor)
