Imports _2___ByteBank.ByteBank

Public Class ContaCorrente

#Region "Construtores"
    Public Sub New(m_saldo As Double)
        Saldo = m_saldo
    End Sub
#End Region
#Region "Propriedades"

    Public Property Titular As Cliente
    Public Property Agencia As Integer
    Public Property conta As Integer
    Public Property m_Saldo As Double
    Public Property Extrato As String


    Public Property Saldo As Double
        Get
            Return m_Saldo
        End Get
        Set(value As Double)
            If (value < 0) Then
                m_Saldo = 0
            Else
                m_Saldo = value
            End If
        End Set
    End Property
#End Region

#Region "Métodos"
    Public Function Sacar(Valor As Double) As Boolean
        Dim retorno As Boolean
        If (m_Saldo < Valor) Then
            retorno = False
        Else
            m_Saldo -= Valor
            retorno = True
        End If
        Return retorno
    End Function

    Public Sub Depositar(Valor As Double)
        m_Saldo += Valor
    End Sub

    Public Function Transferir(Valor As Double, ByRef contaDestino As ContaCorrente) As Boolean
        Dim retorno As Boolean
        If (m_Saldo < Valor) Then
            retorno = False
        Else
            m_Saldo -= Valor
            contaDestino.Depositar(Valor)
            retorno = True
        End If
        Return retorno
    End Function
#End Region

End Class