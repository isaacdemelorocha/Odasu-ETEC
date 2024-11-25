using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odasu_MySQL
{
    internal class Colorir
    {
        // Propriedade para armazenar a cor primária
        public static Color PrimaryColor { get; set; }

        // Propriedade para armazenar a cor secundária
        public static Color SecondaryColor { get; set; }

        // Lista de cores em formato hexadecimal
        public static List<string> ColorList = new List<string>()
        {
            "#3F51B5", "#009688", "#FF5722", "#607D8B", "#FF9800",
            "#9C27B0", "#2196F3", "#EA676C", "#E41A4A", "#5978BB",
            "#018790", "#0E3441", "#00B0AD", "#721D47", "#EA4833",
            "#EF937E", "#F37521", "#A12059", "#126881", "#8BC240",
            "#364D5B", "#C7DC5B", "#0094BC", "#E4126B", "#43B76E",
            "#7BCFE9", "#B71C46"
        };

        /// <summary>
        /// Altera o brilho de uma cor com base em um fator de correção.
        /// Um fator negativo escurece a cor, enquanto um fator positivo a clareia.
        /// </summary>
        /// <param name="color">A cor original que será modificada.</param>
        /// <param name="correctionFactor">Fator de correção para ajustar o brilho.</param>
        /// <returns>A nova cor ajustada.</returns>
        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            // Extrai os componentes de cor
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            // Ajusta o brilho da cor com base no fator de correção
            if (correctionFactor < 0)
            {
                // Escurece a cor
                correctionFactor = 1 + correctionFactor; // Converte para um fator de escurecimento
                red *= correctionFactor; // Aplica o fator à componente vermelha
                green *= correctionFactor; // Aplica o fator à componente verde
                blue *= correctionFactor; // Aplica o fator à componente azul
            }
            else
            {
                // Clareia a cor
                red = (255 - red) * correctionFactor + red; // Ajusta a componente vermelha
                green = (255 - green) * correctionFactor + green; // Ajusta a componente verde
                blue = (255 - blue) * correctionFactor + blue; // Ajusta a componente azul
            }

            // Retorna a nova cor com o componente alfa original
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}