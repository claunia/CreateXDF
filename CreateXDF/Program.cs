using System;
using System.IO;
using System.Text;

namespace CreateXDF
{
    class MainClass
    {
        static readonly byte[] bpb = { 0xEB, 0x4F, 0x90, 0x49, 0x42, 0x4D, 0x20, 0x32, 0x30, 0x2E, 0x30, 0x00, 0x02, 0x01, 0x01, 0x00,
                                       0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                       0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x20, 0x20, 0x20, 0x20,
                                       0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x46, 0x41, 0x54, 0x20, 0x20, 0x20, 0x20, 0x20, 0x00, 0x00,
									   0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0xFA, 0x33, 0xDB, 0x8E, 0xD3, 0xBC, 0xFF, 0x7B, 0xFB, 0xBA,
									   0xC0, 0xFA, 0x29, 0xC0, 0x8E, 0xD0, 0xBC, 0x00, 0x7C, 0xFB, 0x0E, 0x1F, 0xBE, 0x40, 0x7D, 0x8A,
									   0x04, 0x08, 0xC0, 0x74, 0x0D, 0x56, 0x1E, 0xB4, 0x0E, 0xB7, 0x00, 0xCD, 0x10, 0x1F, 0x5E, 0x46,
									   0xEB, 0xED, 0xB4, 0x00, 0xCD, 0x16, 0xCD, 0x19, 0xB9, 0x0B, 0x00, 0xF3, 0x00, 0x29, 0x0D, 0xB6,
									   0x58, 0x44, 0x46, 0x20, 0x76, 0x31, 0x2E, 0x31, 0x61, 0x20, 0x28, 0x63, 0x29, 0x20, 0x31, 0x39,
									   0x39, 0x33, 0x2C, 0x20, 0x31, 0x39, 0x39, 0x34, 0x20, 0x2D, 0x2D, 0x20, 0x42, 0x61, 0x63, 0x6B,
									   0x75, 0x70, 0x20, 0x54, 0x65, 0x63, 0x68, 0x6E, 0x6F, 0x6C, 0x6F, 0x67, 0x69, 0x65, 0x73, 0x2C,
									   0x20, 0x49, 0x6E, 0x63, 0x2E, 0x2C, 0x20, 0x54, 0x61, 0x6D, 0x70, 0x61, 0x20, 0x46, 0x4C, 0x0A,
									   0x20, 0x50, 0x61, 0x74, 0x65, 0x6E, 0x74, 0x28, 0x73, 0x29, 0x20, 0x50, 0x65, 0x6E, 0x64, 0x69,
									   0x6E, 0x67, 0x20, 0x2D, 0x2D, 0x20, 0x49, 0x6E, 0x76, 0x65, 0x6E, 0x74, 0x6F, 0x72, 0x3A, 0x20,
									   0x52, 0x6F, 0x67, 0x65, 0x72, 0x20, 0x44, 0x2E, 0x20, 0x49, 0x76, 0x65, 0x79, 0x0A, 0x41, 0x6C,
									   0x6C, 0x20, 0x72, 0x69, 0x67, 0x68, 0x74, 0x73, 0x20, 0x72, 0x65, 0x73, 0x65, 0x72, 0x76, 0x65,
									   0x64, 0x20, 0x77, 0x6F, 0x72, 0x6C, 0x64, 0x77, 0x69, 0x64, 0x65, 0x0A, 0x44, 0x75, 0x70, 0x6C,
									   0x69, 0x63, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x20, 0x70, 0x72, 0x6F, 0x68, 0x69, 0x62, 0x69, 0x74,
									   0x65, 0x64, 0x20, 0x77, 0x69, 0x74, 0x68, 0x6F, 0x75, 0x74, 0x20, 0x70, 0x65, 0x72, 0x6D, 0x69,
									   0x73, 0x73, 0x69, 0x6F, 0x6E, 0x0A, 0x0A, 0xC0, 0x6E, 0xEF, 0xDD, 0x5F, 0xA5, 0xDA, 0xB1, 0xF7,
									   0x4F, 0x53, 0x2F, 0x32, 0x20, 0x21, 0x21, 0x20, 0x53, 0x59, 0x53, 0x30, 0x31, 0x34, 0x37, 0x35,
									   0x0D, 0x0A, 0x4F, 0x53, 0x2F, 0x32, 0x20, 0x21, 0x21, 0x20, 0x53, 0x59, 0x53, 0x30, 0x32, 0x30,
									   0x32, 0x37, 0x0D, 0x0A, 0x00, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x50, 0x61, 0x74, 0x65, 0x6E,
									   0x74, 0x28, 0x73, 0x29, 0x20, 0x50, 0x65, 0x6E, 0x64, 0x69, 0x6E, 0x67, 0x0D, 0x0A, 0x0D, 0x0A,
									   0x4E, 0x6F, 0x6E, 0x2D, 0x42, 0x6F, 0x6F, 0x74, 0x61, 0x62, 0x6C, 0x65, 0x20, 0x58, 0x44, 0x46,
									   0x20, 0x44, 0x61, 0x74, 0x61, 0x20, 0x44, 0x69, 0x73, 0x6B, 0x0D, 0x0A, 0x49, 0x6E, 0x73, 0x65,
									   0x72, 0x74, 0x20, 0x73, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x20, 0x64, 0x69, 0x73, 0x6B, 0x20, 0x61,
									   0x6E, 0x64, 0x20, 0x70, 0x72, 0x65, 0x73, 0x73, 0x20, 0x61, 0x6E, 0x79, 0x20, 0x6B, 0x65, 0x79,
									   0x0D, 0x0A, 0x00, 0x53, 0x2F, 0x32, 0x20, 0x21, 0x21, 0x20, 0x53, 0x59, 0x53, 0x30, 0x32, 0x30,
									   0x32, 0x37, 0x0D, 0x0A, 0x00, 0x4F, 0x53, 0x32, 0x42, 0x4F, 0x4F, 0x54, 0x20, 0x20, 0x20, 0x20,
									   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
									   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x55, 0xAA };

        static readonly byte[] fatid = { 0xF9, 0xFF, 0xFF };

        const ushort fatSectors = 11;

        const ushort rootEntries = 224;

        const byte formatByte = 0xF6;

        public static void Main(string[] args)
        {
            string volname = "NEW XDF IMG";
            ushort sectors = 0;
            byte mediaDescriptor = 0xF0;
            ushort spt = 0;
            byte unk_sector_num = 0x0B;
            DateTime creation = DateTime.Now;

            if((args.Length != 2 && args.Length != 3) || (args[0] != "-3" && args[0] != "-5"))
            {
                Console.WriteLine("CreateXDF - Creates an empty XDF disk image usable by XDFCOPY or emulators.");
                Console.WriteLine("Usage:");
                Console.WriteLine();
                Console.WriteLine("CreateXDF -3/-5 image.xdf <volumename>");
                Console.WriteLine("\t-3 creates a 3.5\" XDF disk image");
                Console.WriteLine("\t-5 creates a 5.25\" XDF disk image");
                return;
            }

            if (args.Length == 3)
                volname = args[2];

            if (args[0] == "-3")
            {
				spt = 23;
                mediaDescriptor = 0xF0;
                unk_sector_num = 0x0B;
            }
            else if (args[0] == "-5")
            {
                spt = 19;
                mediaDescriptor = 0xF9;
                unk_sector_num = 0x09;
            }
			sectors = (ushort)(80 * 2 * spt);

			FileStream fs = new FileStream(args[1], FileMode.CreateNew, FileAccess.ReadWrite);

            byte[] fat = new byte[fatSectors * 512];
            Array.Copy(fatid, 0, fat, 0, 3);

            byte[] rootDir = new byte[rootEntries * 32];

            Random rand = new Random();
            byte[] serial = new byte[4];
            rand.NextBytes(serial);

            byte[] tmp;
            fs.Write(bpb, 0, 512);
            fs.Seek(0, SeekOrigin.Begin);

            // This is intentionally done step by step :p

            // Skip jump
            fs.Seek(3, SeekOrigin.Current);
            // Skip OEM name
            fs.Seek(8, SeekOrigin.Current);
            // Bytes per sector
            tmp = BitConverter.GetBytes((ushort)512);
            fs.Write(tmp, 0, 2);
            // Sectors per cluster
            fs.WriteByte(1);
			// Reserved sectors between BPB and FAT
			tmp = BitConverter.GetBytes((ushort)1);
			fs.Write(tmp, 0, 2);
			// Number of FATs
			fs.WriteByte(2);
			// Entries in root directory
            tmp = BitConverter.GetBytes(rootEntries);
			fs.Write(tmp, 0, 2);
			// Sectors in volume
            tmp = BitConverter.GetBytes(sectors);
			fs.Write(tmp, 0, 2);
			// Media descriptor
            fs.WriteByte(mediaDescriptor);
			// Sectors per FAT
            tmp = BitConverter.GetBytes(fatSectors);
			fs.Write(tmp, 0, 2);
			// Sectors per track
            tmp = BitConverter.GetBytes(spt);
			fs.Write(tmp, 0, 2);
			// Heads
			tmp = BitConverter.GetBytes((ushort)2);
			fs.Write(tmp, 0, 2);
			// Hidden sectors before BPB
			tmp = BitConverter.GetBytes((uint)0);
			fs.Write(tmp, 0, 4);
			// Sectors in volume if > 65535
			tmp = BitConverter.GetBytes((uint)0);
			fs.Write(tmp, 0, 4);
			// Drive numer
			fs.WriteByte(0);
			// Volume flags
			fs.WriteByte(0);
			// EBPB signature
			fs.WriteByte(0x29);
			// Serial number
			fs.Write(serial, 0, 4);
            // Volume label
            tmp = Encoding.ASCII.GetBytes(volname.ToUpper());
            fs.Write(tmp, 0, tmp.Length >= 11 ? 11 : tmp.Length);

			// Write FATs
			fs.Seek(512, SeekOrigin.Begin);
            fs.Write(fat, 0, fat.Length);
			fs.Write(fat, 0, fat.Length);

            // Create directory entry
            ushort ctime = 0, cdate = 0;
            cdate += (ushort)(((creation.Year - 1980) << 9) & 0xFE00);
            cdate += (ushort)((creation.Month << 5) & 0x1E0);
            cdate += (ushort)creation.Day;
            ctime += (ushort)((creation.Hour << 11) & 0xF800);
            ctime += (ushort)((creation.Minute << 5) & 0x7E0);
            ctime += (ushort)(creation.Second / 2);
            byte[] cdate_b = BitConverter.GetBytes(cdate);
            byte[] ctime_b = BitConverter.GetBytes(ctime);

            // Volume label
            for (int i = 0; i < 11; i++)
                rootDir[i] = 0x20;
			tmp = Encoding.ASCII.GetBytes(volname.ToUpper());
            Array.Copy(tmp, 0, rootDir, 0, tmp.Length >= 11 ? 11 : tmp.Length);
            // Attributes
            rootDir[11] = 8;
            // Case information
            rootDir[12] = 0;
            // Creation time milliseconds. This is DR-DOS so don't use.
            rootDir[13] = 0;
            // Creation time
            Array.Copy(ctime_b, 0, rootDir, 14, 2);
			// Creation date
            Array.Copy(cdate_b, 0, rootDir, 16, 2);
            // Last access date. From Windows 95 so don't use.
            rootDir[18] = 0;
            rootDir[19] = 0;
			// Extended attributes handler
			rootDir[20] = 0;
			rootDir[21] = 0;
			// Last written time
			Array.Copy(ctime_b, 0, rootDir, 22, 2);
			// Last written date
			Array.Copy(cdate_b, 0, rootDir, 24, 2);
			// Starting cluster
			rootDir[26] = 0;
			rootDir[27] = 0;
			// Size
			rootDir[28] = 0;
			rootDir[29] = 0;
			rootDir[30] = 0;
			rootDir[31] = 0;

            fs.Write(rootDir, 0, rootDir.Length);

            ushort remainingSectors = (ushort)(sectors - (fatSectors * 2 + rootDir.Length / 512 + 1));
            tmp = new byte[512];
            for (int i = 0; i < 512; i++)
                tmp[i] = formatByte;
            for (ushort i = 0; i < remainingSectors; i++)
                fs.Write(tmp, 0, 512);

            // Write checksum
            byte[] checksum = BitConverter.GetBytes(xdfcopy_verify_checksum(fs, unk_sector_num));
            fs.Seek(0x13C, SeekOrigin.Begin);
            fs.Write(checksum, 0, 4);

            fs.Close();
		}

        // XDFCOPY algorithm from OBattler's xdfsum.c

        static void xdfcopy_read_file(FileStream fs, uint start, uint len, ref byte[] buf)
        {
            fs.Seek(start << 9, SeekOrigin.Begin);
            buf = new byte[len << 9];
            fs.Read(buf, 0, buf.Length);
        }

        static uint xdfcopy_checksum(ref byte[] buf, ushort len)
        {
            ushort loc2 = 0;
            ushort checksum = 0xABDC;
            ushort i = 0;

            for (i = 0; i < len; i++)
            {
				loc2 = buf[(buf[i] * 0x13) % len];
                checksum += (ushort)((loc2 >> 5) + ((loc2 & 0x1F) << 4));
            }

            return checksum;
        }

        static uint xdfcopy_verify_checksum(FileStream fs, uint unk_sector_num)
        {
            ushort dx;
            short i;
            uint checksum;
            byte[] buf = null;
            byte[] pbuf = new byte[512];

			fs.Seek(0x80, SeekOrigin.Begin);
            fs.Read(pbuf, 0, 0xB6);
            pbuf[0xB6] = 0;
			fs.Seek(0, SeekOrigin.Begin);

			checksum = 0x12345678;
			xdfcopy_read_file(fs, 1, 5, ref buf);                                // sub_72 probably just reads Y sectors from sector X onwards in the image
			checksum = (checksum << 1) + xdfcopy_checksum(ref buf, 0x0A00);
			xdfcopy_read_file(fs, (unk_sector_num << 1) + 1, 5, ref buf);        // from sector 25 onwards for 3.5" 2HD
			checksum = (checksum << 1) + xdfcopy_checksum(ref buf, 0x0A00);
			xdfcopy_read_file(fs, (unk_sector_num << 1) + 6, 5, ref buf);        // from sector 30 onwards for 3.5" 2HD
			checksum = (checksum << 1) + xdfcopy_checksum(ref buf, 0x0A00);

			for (i = 0; i < 0xB6; i++)
			{
                dx = (ushort)(((unk_sector_num << 1) + 0x15) + pbuf[i] + (checksum & 0x7ff));
				xdfcopy_read_file(fs, dx, 1, ref buf);
				checksum = (checksum << 1) + xdfcopy_checksum(ref buf, 0x0200);
			}

			return checksum;
		}
    }
}
