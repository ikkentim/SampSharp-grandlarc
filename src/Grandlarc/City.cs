// Grandlarc
// Copyright 2015 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Grandlarc
{
    public enum City
    {
        LosSantos,
        SanFierro,
        LasVenturas
    }

    public static class CityHelpers
    {
        public static City Next(this City current)
        {
            switch (current)
            {
                case City.LosSantos:
                    return City.SanFierro;
                case City.SanFierro:
                    return City.LasVenturas;
                case City.LasVenturas:
                    return City.LosSantos;
                default: // none case
                    return City.LosSantos;
            }
        }

        public static City Prev(this City current)
        {
            switch (current)
            {
                case City.LosSantos:
                    return City.LasVenturas;
                case City.SanFierro:
                    return City.LosSantos;
                case City.LasVenturas:
                    return City.SanFierro;
                default: // none case
                    return City.LasVenturas;
            }
        }
    }
}