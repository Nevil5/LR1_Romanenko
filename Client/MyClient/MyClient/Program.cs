using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace CSCS1
{
    class SendProgram
    {
        static void Main(string[] args)
        {
            SendMessage();
        }
        private static void SendMessage()
        {
            string remoteAddress = "127.0.0.1";
            int port = 1001;
            Commands commands = new Commands();
            UdpClient sender = new UdpClient(0);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(remoteAddress),
            port);
            Int16 x0, y0;
            Int16 x1, y1;
            Int16 radius;
            string text;
            string hexcolor;
            try
            {
                Console.WriteLine("Напишiть 'help' або '?' для вiдображення списку команд");
                while (true)
                {
                    Console.Write("Введiть команду: ");
                    string commandText = Console.ReadLine();
                    byte[] commandbyte = new byte[1];
                    byte[] result = new byte[1] { 0 };
                    switch (commandText)
                    {
                        case "1":
                        case "Очистити дисплей":
                            commandbyte[0] = 1;
                            hexcolor = ReadHexColor();
                            result = commands.ClearDisplayEncode(commandbyte[0],
                            hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "2":
                        case "Намалювати Пiксель":
                            commandbyte[0] = 2;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            hexcolor = ReadHexColor();
                            result = commands.PixelEncode(commandbyte[0], x0, y0,
                            hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "3":
                        case "Намалювати лiнiю":
                            commandbyte[0] = 3;
                            x0 = ReadNumber("x0", false);
                            y0 = ReadNumber("y0", false);
                            x1 = ReadNumber("x1", false);
                            y1 = ReadNumber("y1", false);
                            hexcolor = ReadHexColor();
                            result = commands.FourNumbersEncode(commandbyte[0],
                            x0, y0, x1, y1, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "4":
                        case "Намалювати прямокутник":
                            commandbyte[0] = 4; x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("Ширина", true);
                            y1 = ReadNumber("Висота", true);
                            hexcolor = ReadHexColor();
                            result = commands.FourNumbersEncode(commandbyte[0],
                            x0, y0, x1, y1, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "5":
                        case "Заповнити прямокутник":
                            commandbyte[0] = 5;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("Ширина", true);
                            y1 = ReadNumber("Висота", true);
                            hexcolor = ReadHexColor();
                            result = commands.FourNumbersEncode(commandbyte[0],
                            x0, y0, x1, y1, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "6":
                        case "Намалювати елiпс":
                            commandbyte[0] = 6;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("радiус x", true);
                            y1 = ReadNumber("радiус y", true);
                            hexcolor = ReadHexColor();
                            result = commands.FourNumbersEncode(commandbyte[0],
                            x0, y0, x1, y1, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "7":
                        case "Заповнити елiпс":
                            commandbyte[0] = 7;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("радiус x", true);
                            y1 = ReadNumber("радiус y", true);
                            hexcolor = ReadHexColor();
                            result = commands.FourNumbersEncode(commandbyte[0],
                            x0, y0, x1, y1, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "8":
                        case "Намалювати коло":
                            commandbyte[0] = 8;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            radius = ReadNumber("радiус", true);
                            hexcolor = ReadHexColor();
                            result = commands.CircleEncode(commandbyte[0], x0, y0,
                            radius, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "9":
                        case "Заповнити коло":
                            commandbyte[0] = 9;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            radius = ReadNumber("радiус", true);
                            hexcolor = ReadHexColor();
                            result = commands.CircleEncode(commandbyte[0], x0, y0,
                            radius, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "10":
                        case "Намалювати прямокутник iз закругленими кутами":
                            commandbyte[0] = 10;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("Ширина", true);
                            y1 = ReadNumber("Висота", true);
                            radius = ReadNumber("радiус", true);
                            hexcolor = ReadHexColor();
                            result = commands.RoundedRectEncode(commandbyte[0],
                            x0, y0, x1, y1, radius, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "11":
                        case "Заповнити прямокутник iз закругленими кутами":
                            commandbyte[0] = 11;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("Ширина", true);
                            y1 = ReadNumber("Висота", true);
                            radius = ReadNumber("радiус", true);
                            hexcolor = ReadHexColor();
                            result = commands.RoundedRectEncode(commandbyte[0],
                            x0, y0, x1, y1, radius, hexcolor);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "12":
                        case "Намалювати текст":
                            commandbyte[0] = 12;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            hexcolor = ReadHexColor();
                            x1 = ReadNumber("Номер шрифту", true);
                            Console.Write("Напишiть текст: ");
                            text = Console.ReadLine();
                            y1 = Convert.ToInt16(text.Length);
                            result = commands.TextEncode(commandbyte[0], x0, y0,
                            hexcolor, x1, y1, text);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "13":
                        case "Намалювати картинку":
                            commandbyte[0] = 13;
                            x0 = ReadNumber("x", false);
                            y0 = ReadNumber("y", false);
                            x1 = ReadNumber("Ширина", true);
                            y1 = ReadNumber("Висота", true);
                            text = ReadPath(); result = commands.ImageEncode(commandbyte[0], x0, y0,
                             x1, y1, text);
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "14":
                        case "Установити орiєнтацiю":
                            commandbyte[0] = 14;
                            x0 = ReadNumber("кут повороту", false);
                            result =
                            commandbyte.Concat(BitConverter.GetBytes(x0)).ToArray();
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "15":
                        case "встановити ширину":
                            commandbyte[0] = 15;
                            sender.Send(commandbyte, commandbyte.Length,
                            endPoint);
                            RecieveMessage(sender, endPoint);
                            break;
                        case "16":
                        case "встановити висоту":
                            commandbyte[0] = 16;
                            sender.Send(commandbyte, commandbyte.Length,
                            endPoint);
                            RecieveMessage(sender, endPoint);
                            break;
                        case "17":
                        case "встановити ширину пера":
                            commandbyte[0] = 17;
                            x0 = ReadNumber("ширина", true);
                            result =
                            commandbyte.Concat(BitConverter.GetBytes(x0)).ToArray();
                            sender.Send(result, result.Length, endPoint);
                            break;
                        case "help":
                        case "?":
                            Console.WriteLine("\nКоманди:");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(" 1. Очистити дисплей");
                            Console.WriteLine(" 2. Намалювати пiксель");
                            Console.WriteLine(" 3. Намалювати лiнiю");
                            Console.WriteLine(" 4. Намалювати прямокутник");
                            Console.WriteLine(" 5. Заповнити прямокутник");
                            Console.WriteLine(" 6. Намалювати елiпс");
                            Console.WriteLine(" 7. Заповнити елiпс");
                            Console.WriteLine(" 8. Намалювати коло");
                            Console.WriteLine(" 9. Заповнити коло");
                            Console.WriteLine(" 10. Намалювати закруглений прямокутник");
                            Console.WriteLine(" 11. Заповнити закруглений прямокутник");
                            Console.WriteLine(" 12. Намалювати текст");
                            Console.WriteLine(" 13. Намалювати зображення");
                            Console.WriteLine(" 14. Встановити орiєнтацiю");
                            Console.WriteLine(" 15. Отримати ширину");
                            Console.WriteLine(" 16. Отримати висоту");
                            Console.ResetColor();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Error! Unknown operation! Tryagain.");
                             Console.ResetColor();
                            break;
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                sender.Close();
            }
        }
        public static bool IsStringInHex(string text)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(text, @"\A\b[0-9afA-F]+\b\Z");
        }
        private static string ReadHexColor()
        {
            string str;
            while (true)
            {
                Console.Write("Вкажiть RGB565 колiр > ");
                str = Console.ReadLine();
                if (IsStringInHex(str) && str.Length <= 4)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка! Спробуйте знову.");
                    Console.ResetColor();
                }
            }
            return str;
        }
        private static Int16 ReadNumber(string text, bool onlyPositive = false)
        {
            string str;
            Int16 number;
            while (true)
            {
                Console.Write($"Вкажiть {text} > ");
                str = Console.ReadLine();
                try
                {
                    number = Int16.Parse(str);
                    if (onlyPositive)
                    {
                        if (number < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Помилка! Поганi данi! (дiапазон вiд 0 до 32767) Спробуйте ще раз.");Console.ResetColor();
                        }
                        else { break; }
                    }
                    else { break; }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка! Поганi данi! (дiапазон вiд -32768 до 32767) Спробуйте ще раз.");
                    Console.ResetColor();
                }
            }
            return Convert.ToInt16(str);
        }
        private static string ReadPath()
        {
            string str;
            while (true)
            {
                Console.Write("Вкажiть путь > ");
                str = Console.ReadLine();
                if (File.Exists(str) && IsImage(str))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка! Файл не iснує! Спробуйте знову.");
                    Console.ResetColor();
                }
            }
            return @"" + str;
        }
        public static bool IsImage(string path)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(path,
            @"^.*\.(jpg|JPG|gif|GIF|png|PNG)$");
        }
        public static void RecieveMessage(UdpClient sender, IPEndPoint endPoint)
        {
            byte[] data = sender.Receive(ref endPoint);
            Console.WriteLine($"Отримане значення: {BitConverter.ToInt16(data, 0)}");
        }
    }
}