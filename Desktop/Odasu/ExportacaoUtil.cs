using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

public static class ExportacaoUtil
{
    public static void ExportarTabela(DataGridView dataGridView)
    {
        using (SaveFileDialog sfd = new SaveFileDialog())
        {
            sfd.Filter = "CSV files (*.csv)|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    // Escreve os cabeçalhos
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        sw.Write(dataGridView.Columns[i].HeaderText);
                        if (i < dataGridView.Columns.Count - 1) sw.Write(",");
                    }
                    sw.WriteLine();

                    // Escreve as linhas
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            sw.Write(row.Cells[i].Value?.ToString());
                            if (i < row.Cells.Count - 1) sw.Write(",");
                        }
                        sw.WriteLine();
                    }
                }
                MessageBox.Show("Exportação para CSV concluída.");
            }
        }
    }

    public static void ExportarPDF(DataGridView dataGridView)
    {
        using (SaveFileDialog sfd = new SaveFileDialog())
        {
            sfd.Filter = "PDF files (*.pdf)|*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                doc.Open();

                // Adiciona um título
                doc.Add(new Paragraph("Relatório de Estoque"));

                // Cria uma tabela com o número de colunas
                PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count);

                // Adiciona os cabeçalhos
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    pdfTable.AddCell(column.HeaderText);
                }

                // Adiciona as linhas
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdfTable.AddCell(cell.Value?.ToString());
                    }
                }

                doc.Add(pdfTable);
                doc.Close();

                MessageBox.Show("Exportação para PDF concluída.");
            }
        }
    }
}