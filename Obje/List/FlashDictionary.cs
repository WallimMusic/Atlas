﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obje.List
{
    public class FlashDictionary
    {
        public static readonly Dictionary<int, string> Direction = new Dictionary<int, string>
        {
            { 1, "GİRİŞ" },
            { 0, "ÇIKIŞ" }
        };

        public static readonly Dictionary<int, string> plugTypes = new Dictionary<int, string>
        {
            { 100, "Açılış Fişi" },
            { 101, "Sayım Fişi" }
        };

        public static readonly Dictionary<int, string> cusTypes = new Dictionary<int, string>
        {
            { 200, "Alıcı" },
            { 201, "Satıcı" },
            { 202, "Alıcı + Satıcı" }
        };

        public static readonly Dictionary<int, string> campaingTypes = new Dictionary<int, string>
        {
            { 300, "X al Y öde" },
            { 301, "X ₺'ye Y İndirim" }
        };

        public static readonly Dictionary<int, string> discountType = new Dictionary<int, string>
        {
            { 400, "Yüzde" },
            { 401, "Tutar" }
        };

        public static readonly Dictionary<int, string> movementTypesOnStock = new Dictionary<int, string>
        {
            { 500, "Satınalma" },
            { 501, "Satınalma İadesi" },
            { 502, "Toplu Satış" },
            { 503, "Toplu Satış İadesi" },
            { 504, "Perakende Satış" },
            { 505, "Perakende Satış İadesi" },
            { 506, "Açılış Fişi" },
            { 507, "Açılış Fişi İadesi" },
            { 508, "Sayım Fişi" },
            { 509, "Sayım Fişi İadesi" },
            { 508, "Depolar Arası Transfer" },
            { 509, "Depolar Arası Transfer İadesi" }
        };




    }
}
