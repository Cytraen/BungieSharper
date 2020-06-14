/*
   Copyright (C) 2020 ashakoor

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU Affero General Public License as
   published by the Free Software Foundation, either version 3 of the
   License or any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU Affero General Public License for more details.

   You should have received a copy of the GNU Affero General Public License
   along with this program. If not, see <https://www.gnu.org/licenses/>.

   BungieSharper accesses an API under the BSD 3-Clause License.
   See BUNGIE-SDK-LICENSE for more information.
   The Bungie API/SDK is copyright (c) 2017, Bungie, Inc.
*/

namespace BungieSharper.Generator.Generation
{
    internal static class FormatSummaries
    {
        public static string FormatSummary(string summary, int spaces)
        {
            var formatted = "";
            var spacing = "".PadLeft(spaces, ' ');

            summary = summary.Replace("\r\n", "\n");

            if (summary.Contains('\n'))
            {
                formatted += $"{spacing}/// <summary>\n";
                formatted += spacing + string.Join("", summary.Split($"{spacing}\n"));
                formatted += $"{spacing}/// </summary>";
            }
            else
            {
                formatted = "";
            }

            return formatted;
        }
    }
}
