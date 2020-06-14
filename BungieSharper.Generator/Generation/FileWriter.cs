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

using System.IO;
using System.Text;

namespace BungieSharper.Generator.Generation
{
    internal static class FileWriter
    {
        public static void WriteFileWithContent(string fileFolder, string fileName, string fileContent)
        {
            Directory.CreateDirectory(fileFolder);

            File.WriteAllText(fileFolder + "\\" + fileName, fileContent.Replace("\r\n", "\n").Replace("\n", "\r\n"), Encoding.UTF8);
        }
    }
}