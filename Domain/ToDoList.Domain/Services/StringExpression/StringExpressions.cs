using System.Text.RegularExpressions;

namespace Domain.Services.StringExpression;

/// <summary>
/// Classe parcial contendo expressões de string relacionadas.
/// </summary>
public partial class StringExpressions
{
    /// <summary>
    /// Divide sentenças em uma única palavra, removendo espaços extras entre palavras.
    /// </summary>
    /// <param name="input">A string de entrada a ser processada.</param>
    /// <returns>A string resultante após dividir sentenças com um espaço.</returns>
    public static string SplitSentencesWithOneSpace(string input) => MyRegex().Replace(input, " ").Trim().ToString();

    /// <summary>
    /// Método gerado para fornecer a expressão regular usada para dividir sentenças com um espaço.
    /// </summary>
    /// <returns>Expressão regular compilada.</returns>
    [GeneratedRegex(@"\s+")]
    private static partial Regex MyRegex();
}
