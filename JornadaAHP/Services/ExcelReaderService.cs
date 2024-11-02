using JornadaAHP.Data;
using JornadaAHP.Enums;
using JornadaAHP.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Drawing;

namespace JornadaAHP.Services
{
    public class ExcelReaderService
    {
        private readonly AppDbContext _context;

        public ExcelReaderService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Motor>> LerMotoresDoArquivo(string filePath)
        {
            try
            {
                var motores = new List<Motor>();

                // Definir a cultura para parsing de números corretamente
                var culture = new CultureInfo("pt-BR");
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(filePath))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // Pular a primeira linha (cabeçalho)
                    {
                        decimal teste = Convert.ToDecimal(worksheet.Cells[row, 10].Value?.ToString().Replace("R$", "").Trim(), culture);
                        var motor = new Motor
                        {
                            Empresa = worksheet.Cells[row, 1].Value?.ToString(),
                            Categoria = worksheet.Cells[row, 2].Value?.ToString(), // Se todas as categorias forem fixas
                            PartNumber = worksheet.Cells[row, 3].Value?.ToString(),
                            ForcaMaxima = Convert.ToDecimal(worksheet.Cells[row, 4].Value, culture),
                            ForcaMedia = Convert.ToDecimal(worksheet.Cells[row, 5].Value, culture),
                            RpmMaximo = Convert.ToInt32(worksheet.Cells[row, 6].Value),
                            RpmMedio = Convert.ToInt32(worksheet.Cells[row, 7].Value),
                            Peso = Convert.ToDecimal(worksheet.Cells[row, 8].Value, culture), 
                            Prazo = Convert.ToInt32(worksheet.Cells[row, 9].Value),
                            Valor = Convert.ToDecimal(worksheet.Cells[row, 10].Value?.ToString().Replace("R$", "").Trim(), culture),
                            Drive = new Drive
                            //TODO: Adicionar porcentagemw
                            {
                                PartNumber = worksheet.Cells[row, 11].Value?.ToString(),
                                Preco = Convert.ToDecimal(worksheet.Cells[row, 12].Value?.ToString().Replace("R$", "").Trim(), culture)
                            },
                            Fonte = new Fonte
                            {
                                PartNumber = worksheet.Cells[row, 13].Value?.ToString(),
                                Preco = Convert.ToDecimal(worksheet.Cells[row, 14].Value?.ToString().Replace("R$", "").Trim(), culture)
                            }
                            
                           
                        };
                        motor.ValorTotal = motor.Valor + motor.Fonte.Preco + motor.Drive.Preco;

                        motores.Add(motor);
                    }
                }
                await SalvarMotoresNoBanco(motores);
                return motores;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                List<Motor> motoreserro = new List<Motor>();
                return motoreserro;
            }
            
        }

        public async Task SalvarMotoresNoBanco(List<Motor> motores)
        {
            try 
            {
                foreach (var motor in motores)
                {
                    // Verifique se o Drive já existe para evitar duplicações
                    var driveExistente = await _context.Drives.FirstOrDefaultAsync(d => d.PartNumber == motor.Drive.PartNumber);
                    if (driveExistente != null)
                    {
                        motor.DriveId = driveExistente.Id;
                        motor.Drive = driveExistente;
                    }
                    else
                    {
                        _context.Drives.Add(motor.Drive);
                    }

                    // Verifique se a Fonte já existe para evitar duplicações
                    var fonteExistente = await _context.Fontes.FirstOrDefaultAsync(f => f.PartNumber == motor.Fonte.PartNumber);
                    if (fonteExistente != null)
                    {
                        motor.FonteId = fonteExistente.Id;
                        motor.Fonte = fonteExistente;
                    }
                    else
                    {
                        _context.Fontes.Add(motor.Fonte);
                    }

                    _context.Motores.Add(motor);
                }

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
