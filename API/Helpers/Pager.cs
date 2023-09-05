using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers;
public class Pager<T> where T : class
{
    public string Search  { get; set; }
    public int PageIndex { get; set;}
    public int PageSize { get; set;}
    public int Total { get; set; }
    public List<T> Registers { get; private set; }

    public Pager(){}

    public Pager(List<T> registers, int total, int pageIndex, int pageSize, string search)
    {
        Registers = registers;
        Total = total;
        PageIndex = pageIndex;
        PageSize = pageSize;
        Search = search;
    }
    
}