using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Processors.MJPEG
{
    static partial class Extensions
    {
        public static int Find(this byte[] buff, byte[] search)
        {

            for (int start = 0; start < buff.Length - search.Length; start++)
            {
                // первый символ
                if (buff[start] == search[0])
                {
                    int next;

                    // последующие символы
                    for (next = 1; next < search.Length; next++)
                    {
                        // последующие не найдены
                        if (buff[start + next] != search[next])
                            break;
                    }

                    if (next == search.Length)
                        return start;
                }
            }
            // ничего не найдено
            return -1;
        }
    }
}