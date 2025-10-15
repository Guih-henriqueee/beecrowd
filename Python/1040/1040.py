n1, n2, n3, n4 = input().split(' ')

n1 = float(n1) * 2
n2 = float(n2) * 3
n3 = float(n3) * 4
n4 = float(n4) * 1

mediaparcial = (n1 + n2 + n3 + n4) / 10

def recuperacao (mediaparcial):
    nr = float(input())
    mediarecuperada = (mediaparcial + nr) / 2
    
    if mediaparcial >= 5:
        print(f'Media: {mediaparcial:.1f}\nAluno em exame.\nNota do exame: {nr:.1f}\nAluno aprovado.\nMedia final: {mediarecuperada:.1f}')
    else:
        print(f'Aluno em exame\nNota do exame: {nr:.1f}\nAluno Reprovado.\nMedia final: {mediarecuperada:.1f}')

def avaliacao(mediaparcial):
    if mediaparcial > 7.0:
          print(f'Media: {mediaparcial:.1f}\nAluno Aprovado.')
    elif mediaparcial < 5:
         print(f'Media: {mediaparcial:.1f}\nAluno reprovado.')
    else:
         recuperacao(mediaparcial)

avaliacao(mediaparcial)
