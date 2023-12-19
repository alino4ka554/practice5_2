using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice5_2
{
    public enum RAM_type
    {
        DDR = 1, DDR2, DDR3, DDR4, DDR5
    }

    public enum OS
    {
        Android = 1, iOS, WindowsPhone
    }
        public class Smartphone
        {
            private string firm;
            private string model;
            private int hz;
            private int core;
            private int ram;
            private RAM_type typeram;
            private int secmem;
            private OS os;
            public Dictionary<string, int> apps;
            private long imei;

            public Smartphone(string _firm, string _model, int _hz, int _core, int _ram, RAM_type _typeram, int _secmem, OS _os, long _imei)
            {
                if (string.IsNullOrEmpty(_firm)) throw new ArgumentException("Некорректный ввод названия фирмы-производителя!");
                for (int i = 0; i < _firm.Length; i++)
                {
                    if ((_firm[i] <= 44) || (_firm[i] >= 46 && _firm[i] <= 64) || (_firm[i] >= 91 && _firm[i] <= 96) || (_firm[i] >= 123 && _firm[i] < 255))
                    {
                        throw new ArgumentException("Некорректный ввод названия фирмы-производителя!");
                    }
                    else
                        firm = _firm;
                }
                if (string.IsNullOrEmpty(_model)) throw new ArgumentException("Некорректный ввод названия модели!");
                for (int i = 0; i < _model.Length; i++)
                {
                    if ((_model[i] <= 31) || (_model[i] >= 33 && _model[i] <= 44) || (_model[i] >= 58 && _model[i] <= 64) || (_model[i] >= 91 && _model[i] <= 96) || (_model[i] >= 123 && _model[i] < 255))
                    {
                        throw new ArgumentException("Некорректный ввод названия модели!");
                    }
                    else
                        model = _model;
                }
                if ((_hz < 1000) || (_hz > 4000))
                    throw new ArgumentException("Частота ЦПУ может быть только от 1000 до 4000!");
                else
                    hz = _hz;
                if ((_core < 4) || (_core > 10))
                    throw new ArgumentException("Количество ядер может быть только от 4 до 10!");
                else
                    core = _core;
                if ((_ram < 4) || (_ram > 8))
                    throw new ArgumentException("Объем оперативной памяти может быть только от 4 до 8!");
                else
                    ram = _ram;
                if (_typeram != RAM_type.DDR && _typeram != RAM_type.DDR2 && _typeram != RAM_type.DDR3 && _typeram != RAM_type.DDR4 && _typeram != RAM_type.DDR5)
                    throw new ArgumentException("Некорректный ввод типа оперативной памяти!");
                else
                    typeram = _typeram;
                if ((_secmem < 4) || (_secmem > 1024))
                    throw new ArgumentException("Объем вторичной памяти может быть только от 4 до 1024 Гб!");
                else
                    secmem = _secmem * 1024;
                if (_os != OS.Android && _os != OS.iOS && _os != OS.WindowsPhone)
                    throw new ArgumentException("Некорректный ввод типа оперативной системы!");
                else
                    os = _os;
                if (_imei.ToString().Length != 16)
                    throw new ArgumentException("Длина IMEI должна быть 16!");
                else
                    imei = _imei;
                apps = new Dictionary<string, int>(); //инициализируем поле apps пустым словарем
            }


            public string Firm
            {
                set
                {
                    if (string.IsNullOrEmpty(value)) throw new Exception("Некорректный ввод названия фирмы-производителя!");
                    for (int i = 0; i < value.Length; i++)
                    {
                        if ((value[i] <= 44) || (value[i] >= 46 && value[i] <= 64) || (value[i] >= 91 && value[i] <= 96) || (value[i] >= 123 && value[i] < 255))
                        {
                            throw new Exception("Некорректный ввод названия фирмы-производителя!");
                        }
                    }
                    firm = value;
                }
                get { return firm; }
            }

            public string Model
            {
                set
                {
                    if (string.IsNullOrEmpty(value)) throw new Exception("Некорректный ввод названия модели!");
                    for (int i = 0; i < value.Length; i++)
                    {
                        if ((value[i] <= 31) || (value[i] >= 33 && value[i] <= 44) || (value[i] >= 58 && value[i] <= 64) || (value[i] >= 91 && value[i] <= 96) || (value[i] >= 123 && value[i] < 255))
                        {
                            throw new Exception("Некорректный ввод названия модели!");
                        }
                    }
                    model = value;
                }
                get { return model; }
            }

            public int HzValue
            {
                set
                {
                    if (value < 1000 || value > 4000)
                        throw new Exception("Частота ЦПУ может быть только от 1000 до 4000!");
                    hz = value;
                }

                get { return hz; }
            }

            public int Core
            {
                set
                {
                    if (value < 4 || value > 10)
                        throw new Exception("Количество ядер может быть только от 4 до 10!");
                    core = value;
                }
                get { return core; }
            }

            public int RAMSize
            {
                set
                {
                    if (value >= 4 || value <= 8)
                        throw new Exception("Объем оперативной памяти может быть только от 4 до 8!");
                    ram = value;
                }
                get { return ram; }
            }

            public RAM_type RAMType
            {
                set
                {
                    if (value != RAM_type.DDR && value != RAM_type.DDR2 && value != RAM_type.DDR3 && value != RAM_type.DDR4 && value != RAM_type.DDR5)
                        throw new Exception("Некорректный ввод типа оперативной памяти!");
                    typeram = value;
                }
                get { return typeram; }
            }

            public int SecondaryMemory
            {
                set
                {
                    if (value < 4 || value > 1024)
                        throw new Exception("Объем вторичной памяти может быть только от 4 до 1024 Гб!");
                    secmem = value * 1024;
                }
                get { return secmem; }
            }

            public OS OperatingSystem
            {
                set
                {
                    if (value != OS.Android && value != OS.iOS && value != OS.WindowsPhone)
                        throw new Exception("Некорректный ввод типа оперативной системы!");
                    os = value;
                }
                get { return os; }
            }

            public long IMEI
            {
                set
                {
                    if (value.ToString().Length != 16)
                        throw new Exception("Длина IMEI должна быть 16!");
                    imei = value;
                }

                get { return imei; }
            }

            public int average_num_apps_for_free_mem() //среднее количество возможно установленных приложений
            {
                int av_app_free;
                av_app_free = (secmem - 2048) / 300; //средний объем приложения возьмем за 300 мб, 2048 берем как объем операционной системы 
                return av_app_free;
            }

            public bool hard_reset() //удаление всех приложений
            {
                
                    ExamAppPrint(); //проверка на наличие приложений
                    foreach (var app in apps)
                    {
                        secmem += app.Value; //возвращаем память
                    }
                    apps.Clear();
                    Console.WriteLine($"Все приложения удалены. Свободной памяти для установки приложений: {secmem - 2048} Мб"); //-2048, т.к. вся ВП не может быть занята приложениями
                    return true;
                
            }


            public bool DeleteApp(string appName)
            {
                
                    ExamAppInst(appName); //проверяем есть ли приложение с таким названием
                    if (apps.TryGetValue(appName, out int appSize))
                    {
                        apps.Remove(appName); //удаляем приложение
                        secmem = secmem + appSize; //очищаем память от приложения
                        Console.WriteLine($"Приложение {appName} удалено.");
                        return true;
                    }
                    else return false;

            }

            public bool IsAppInstalled(string appName) //проверка наличия приложения с данным названием
            {
                return apps.ContainsKey(appName);
            }

            public bool InstallApp(string appName, int appSize)
            {
                {
                    ExamAppSize(appSize); //проверяем корректность памяти приложения
                    secmem = secmem - appSize; //уменьшаем ВП 
                    ExamApp(appName); //проверяем установлено ли приложение
                    if (!apps.ContainsKey(appName))
                    {
                        apps.Add(appName, appSize);
                        Console.WriteLine($"Установлено приложение {appName}, занимаемая память: {appSize} Мб.");
                        return true;
                    }
                    else return false;
                }
            }


            public bool ExamAppSize(int appSize)
            {
                if (appSize <= 0) { throw new ArgumentException("Приложение не может быть установлено из-за некорректной занимаемой памяти!"); }
                else if (appSize + 2048 >= secmem) //память на смартфоне не может быть полностью занята приложениями
                {
                    throw new ArgumentException("Недостаточно места для данного приложения!");
                }
                else return true;
            }

            private void ExamAppInst(string appName)
            {
                if (!IsAppInstalled(appName)) throw new ArgumentException("Данное приложение не установлено.");
            }

            public void ExamApp(string appName)
            {
                if (IsAppInstalled(appName)) throw new ArgumentException("Приложение уже установлено!");
            }


            public void ExamAppPrint()
            {
                if (apps.Count == 0) throw new ArgumentException("На смартфоне не установлено ни одного приложения.");
            }
        }

}
