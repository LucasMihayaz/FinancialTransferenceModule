Imports _2___ByteBank.ByteBank

Public Class Frm_Principal_02
    Dim ContaLucas As New ContaCorrente("3800")
    Dim ContaMilena As New ContaCorrente("2500")
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'Inicializando dados do cliente 01

        Me.Text = "2 - ByteBank"
        lbl_valor_lucas.Text = "Valor a ser sacado/depositado"
        btn_efetuar_saque_lucas.Text = "Efetuar saque"
        btn_transferir_lucas.Text = "Efetuar transferência"
        btn_depositar_lucas.Text = "Efetuar depósito"
        lbl_novo_saldo_lucas.Text = "Novo Saldo"
        lbl_resultado_lucas.Text = "Resultado do saque"
        lbl_saldo_atual_lucas.Text = "Saldo Atual"
        grp_lucas.Text = "Lucas"

        txt_saldo_atual_lucas.ReadOnly = True
        txt_novo_saldo_lucas.ReadOnly = True
        txt_retorno_lucas.ReadOnly = True
        txt_extrato_lucas.ReadOnly = True

        'Inicializando dados do cliente 02
        lbl_valor_milena.Text = "Valor a ser sacado/depositado"
        btn_efetuar_saque_milena.Text = "Efetuar saque"
        btn_transferir_milena.Text = "Efetuar transferência"
        btn_depositar_milena.Text = "Efetuar depósito"
        lbl_novo_saldo_milena.Text = "Novo Saldo"
        lbl_resultado_milena.Text = "Resultado do saque"
        lbl_saldo_atual_milena.Text = "Saldo Atual"
        grp_milena.Text = "Milena"

        txt_saldo_atual_milena.ReadOnly = True
        txt_novo_saldo_milena.ReadOnly = True
        txt_retorno_milena.ReadOnly = True
        txt_extrato_milena.ReadOnly = True

        'Inicializando dados da classe do cliente 01
        Dim cliente01 As New Cliente("Lucas Silva", "01365475065")
        cliente01.Profissao = "Desenvolvedor backend jr"
        cliente01.Cidade = "Curitiba"

        ContaLucas.Titular = cliente01
        ContaLucas.Agencia = 863
        ContaLucas.Conta = 863141

        lbl_bem_vindo_cliente_lucas.Text = "Bem vindo (a) " + ContaLucas.Titular.Nome
        lbl_dados_conta_lucas.Text = "Agência :  " + ContaLucas.Agencia.ToString _
            + " Conta: " + ContaLucas.Conta.ToString
        txt_saldo_atual_lucas.Text = ContaLucas.Saldo.ToString

        'Inicializando dados da classe do cliente 02

        Dim cliente02 As New Cliente("Milena Strassburger", "11465845361")
        cliente02.Profissao = "Analista de marketing"
        cliente02.Cidade = "Curitiba"

        ContaMilena.Titular = cliente02
        ContaMilena.Agencia = 811
        ContaMilena.Conta = 811592

        lbl_bem_vindo_cliente_milena.Text = "Bem vindo (a) " + ContaMilena.Titular.Nome
        lbl_dados_conta_milena.Text = "Agência :  " + ContaMilena.Agencia.ToString _
            + " Conta: " + ContaMilena.Conta.ToString
        txt_saldo_atual_milena.Text = ContaMilena.Saldo.ToString

    End Sub

    Private Sub Frm_Principal_02_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_depositar_lucas_Click(sender As Object, e As EventArgs) Handles btn_depositar_lucas.Click
        txt_retorno_lucas.Text = ""
        txt_novo_saldo_lucas.Text = ""
        Dim valorDeposito As Double = Val(txt_valor_lucas.Text)
        ContaLucas.Depositar(valorDeposito)
        txt_novo_saldo_lucas.Text = ContaLucas.Saldo.ToString
        txt_saldo_atual_lucas.Text = txt_novo_saldo_lucas.Text
        ContaLucas.Extrato += Now.ToString + " Depósito de " + valorDeposito.ToString + vbCrLf
        txt_extrato_lucas.Text = ContaLucas.Extrato
        txt_retorno_lucas.Text = "Depósito efetuado com sucesso"
    End Sub

    Private Sub btn_efetuar_saque_lucas_Click(sender As Object, e As EventArgs) Handles btn_efetuar_saque_lucas.Click
        txt_retorno_lucas.Text = ""
        txt_novo_saldo_lucas.Text = ""
        Dim valorSacar As Double = Val(txt_valor_lucas.Text)
        Dim retornoSaque As Boolean = ContaLucas.Sacar(valorSacar)
        If (retornoSaque = False) Then
            txt_retorno_lucas.Text = "Não foi possível efetuar o saque"
        Else
            txt_novo_saldo_lucas.Text = ContaLucas.Saldo.ToString
            txt_saldo_atual_lucas.Text = txt_novo_saldo_lucas.Text
            ContaLucas.Extrato += Now.ToString + " Saque de " + valorSacar.ToString + vbCrLf
            txt_extrato_lucas.Text = ContaLucas.Extrato
            txt_retorno_lucas.Text = "Saque efetuado com sucesso"
        End If
    End Sub

    Private Sub btn_transferir_lucas_Click(sender As Object, e As EventArgs) Handles btn_transferir_lucas.Click
        txt_retorno_lucas.Text = ""
        txt_novo_saldo_lucas.Text = ""
        Dim valorTransferir As Double = Val(txt_valor_lucas.Text)
        Dim retornoTransferencia As Boolean = ContaLucas.Transferir(valorTransferir, ContaMilena)
        If (retornoTransferencia = False) Then
            txt_retorno_lucas.Text = "Transferência não é possível ser feita"
        Else
            txt_novo_saldo_lucas.Text = ContaLucas.Saldo.ToString
            txt_novo_saldo_milena.Text = ContaMilena.Saldo.ToString
            txt_saldo_atual_lucas.Text = txt_novo_saldo_lucas.Text
            txt_saldo_atual_milena.Text = txt_novo_saldo_milena.Text

            ContaLucas.Extrato += Now.ToString + " Transferência de " + valorTransferir.ToString + vbCrLf
            txt_extrato_lucas.Text = ContaLucas.Extrato
            ContaMilena.Extrato += Now.ToString + " Transferência de " + valorTransferir.ToString + vbCrLf

            txt_extrato_lucas.Text = ContaLucas.Extrato
            txt_extrato_milena.Text = ContaMilena.Extrato
            txt_retorno_lucas.Text = "Transferência efetuada com sucesso"
        End If
    End Sub

    Private Sub btn_depositar_milena_Click(sender As Object, e As EventArgs) Handles btn_depositar_milena.Click
        txt_retorno_milena.Text = ""
        txt_novo_saldo_milena.Text = ""
        Dim valorDeposito As Double = Val(txt_valor_milena.Text)
        ContaMilena.Depositar(valorDeposito)
        txt_novo_saldo_milena.Text = ContaMilena.Saldo.ToString
        txt_saldo_atual_milena.Text = txt_novo_saldo_milena.Text
        ContaMilena.Extrato += Now.ToString + " Depósito de " + valorDeposito.ToString + vbCrLf
        txt_extrato_milena.Text = ContaMilena.Extrato
        txt_retorno_milena.Text = "Depósito efetuado com sucesso"
    End Sub

    Private Sub btn_efetuar_saque_milena_Click(sender As Object, e As EventArgs) Handles btn_efetuar_saque_milena.Click
        txt_retorno_milena.Text = ""
        txt_novo_saldo_milena.Text = ""
        Dim valorSacar As Double = Val(txt_valor_milena.Text)
        Dim retornoSaque As Boolean = ContaMilena.Sacar(valorSacar)
        If (retornoSaque = False) Then
            txt_retorno_milena.Text = "Não foi possível efetuar o saque"
        Else
            txt_novo_saldo_milena.Text = ContaMilena.Saldo.ToString
            txt_saldo_atual_milena.Text = txt_novo_saldo_milena.Text
            ContaMilena.Extrato += Now.ToString + " Saque de " + valorSacar.ToString + vbCrLf
            txt_extrato_milena.Text = ContaMilena.Extrato
            txt_retorno_milena.Text = "Saque efetuado com sucesso"
        End If
    End Sub

    Private Sub btn_transferir_milena_Click(sender As Object, e As EventArgs) Handles btn_transferir_milena.Click
        txt_retorno_milena.Text = ""
        txt_novo_saldo_milena.Text = ""
        Dim valorTransferir As Double = Val(txt_valor_milena.Text)
        Dim retornoTransferencia As Boolean = ContaMilena.Transferir(valorTransferir, ContaLucas)
        If (retornoTransferencia = False) Then
            txt_retorno_milena.Text = "Transferência não é possível ser feita"
        Else
            txt_novo_saldo_lucas.Text = ContaLucas.Saldo.ToString
            txt_novo_saldo_milena.Text = ContaMilena.Saldo.ToString
            txt_saldo_atual_lucas.Text = txt_novo_saldo_lucas.Text
            txt_saldo_atual_milena.Text = txt_novo_saldo_milena.Text

            ContaLucas.Extrato += Now.ToString + " Transferência de " + valorTransferir.ToString + vbCrLf
            txt_extrato_lucas.Text = ContaLucas.Extrato
            ContaMilena.Extrato += Now.ToString + " Transferência de " + valorTransferir.ToString + vbCrLf

            txt_extrato_lucas.Text = ContaLucas.Extrato
            txt_extrato_milena.Text = ContaMilena.Extrato
            txt_retorno_milena.Text = "Transferência efetuada com sucesso"
        End If
    End Sub
End Class
