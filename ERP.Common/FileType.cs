using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace CZZD.ERP.Common
{
    public class FileType
    {
        private static Hashtable _fileType = null;

        public static Hashtable GetFileType()
        {
            if (_fileType == null)
            {
                //_fileType = new Hashtable();
                //_fileType.Add("FFD8FFE1", "jpg");
                //_fileType.Add("89504E47", "png");
                //_fileType.Add("47494638", "gif");
                //_fileType.Add("49492A00", "tif");
                //_fileType.Add("424D", "bmp");
                //_fileType.Add("41433130", "dwg");
                //_fileType.Add("38425053", "psd");
                //_fileType.Add("7B5C727466", "rtf");
                //_fileType.Add("3C3F786D6C", "xml");
                //_fileType.Add("68746D6C3E", "html");
                //_fileType.Add("44656C69766572792D646174", "eml");
                //_fileType.Add("CFAD12FEC5FD746F", "dbx");
                //_fileType.Add("2142444E", "pst");
                //_fileType.Add("D0CF11E0", "xls/doc");
                //_fileType.Add("5374616E64617264204A", "mdb");
                //_fileType.Add("FF575043", "wpd");
                //_fileType.Add("252150532D41646F6265", "eps/ps");
                //_fileType.Add("255044462D312E", "pdf");
                //_fileType.Add("E3828596", "pwl");
                //_fileType.Add("504B0304", "zip");
                //_fileType.Add("52617221", "rar");
                //_fileType.Add("57415645", "wav");
                //_fileType.Add("41564920", "avi");
                //_fileType.Add("2E7261FD", "ram");
                //_fileType.Add("2E524D46", "rm");
                //_fileType.Add("000001BA", "mpg");
                //_fileType.Add("000001B3", "mpg");
                //_fileType.Add("6D6F6F76", "mov");
                //_fileType.Add("3026B2758E66CF11", "asf");
                //_fileType.Add("4D546864", "mid");

                //_fileType = new Hashtable();
                //_fileType.Add("FFD8FF", "JPEG (jpg)");
                //_fileType.Add("89504E47","PNG (png)");
                //_fileType.Add("47494638","GIF (gif)");
                //_fileType.Add("49492A00","TIFF (tif)");
                //_fileType.Add("424D","Windows Bitmap (bmp)");
                //_fileType.Add("41433130","CAD (dwg)");
                //_fileType.Add("38425053","Adobe Photoshop (psd)");
                //_fileType.Add("7B5C727466","Rich Text Format (rtf)");
                //_fileType.Add("3C3F786D6C","XML (xml)");
                //_fileType.Add("68746D6C3E","HTML (html)");
                //_fileType.Add("44656C69766572792D646174653A","Email [thorough only] (eml)");
                //_fileType.Add("CFAD12FEC5FD746F","Outlook Express (dbx)");
                //_fileType.Add("2142444E","Outlook (pst)");
                //_fileType.Add("D0CF11E0","MS Word/Excel (xls.or.doc)");
                //_fileType.Add("5374616E64617264204A","MS Access (mdb)");
                //_fileType.Add("FF575043","WordPerfect (wpd)");
                //_fileType.Add("252150532D41646F6265","Postscript (eps.or.ps)");
                //_fileType.Add("255044462D312E","Adobe Acrobat (pdf)");
                //_fileType.Add("AC9EBD8F","Quicken (qdf)");
                //_fileType.Add("E3828596","Windows Password (pwl)");
                //_fileType.Add("504B0304","ZIP Archive (zip)");
                //_fileType.Add("52617221","RAR Archive (rar)");
                //_fileType.Add("57415645","Wave (wav)");
                //_fileType.Add("41564920","AVI (avi)");
                //_fileType.Add("2E7261FD","Real Audio (ram)");
                //_fileType.Add("2E524D46","Real Media (rm)");
                //_fileType.Add("000001BA","MPEG (mpg)");
                //_fileType.Add("000001B3","MPEG (mpg)");
                //_fileType.Add("6D6F6F76","Quicktime (mov)");
                //_fileType.Add("3026B2758E66CF11","Windows Media (asf)");
                //_fileType.Add("4D546864","MIDI (mid)");


                _fileType = new Hashtable();
                _fileType.Add("JPG", "JPEG　图片文件(jpg)");
                _fileType.Add("PNG", "PNG　图片文件(png)");
                _fileType.Add("GIF", "GIF 图片文件(gif)");
                _fileType.Add("TIFF", "TIFF 图片文件(tif)");
                _fileType.Add("BMP", "Windows Bitmap 图片文件(bmp)");
                _fileType.Add("DWG", "CAD 绘图文件(dwg)");
                _fileType.Add("PSD", "Adobe Photoshop 图片文件(psd)");
                _fileType.Add("RTF", "Rich Text Format (rtf)");
                _fileType.Add("XML", "XML 文本文件(xml)");
                _fileType.Add("HTML", "HTML (html)");
                _fileType.Add("EML", "Email [thorough only] (eml)");
                _fileType.Add("DBX", "Outlook Express (dbx)");
                _fileType.Add("PST", "Outlook (pst)");
                _fileType.Add("XLS", "MS Word/Excel (xls.or.doc)");
                _fileType.Add("DOC", "MS Word/Excel (xls.or.doc)");
                _fileType.Add("XLSX", "MS Word/Excel (xlsx.or.docx)");
                _fileType.Add("DOCX", "MS Word/Excel (xlsx.or.docx)");
                _fileType.Add("MDB", "MS Access (mdb)");
                _fileType.Add("WPD", "WordPerfect (wpd)");                
                _fileType.Add("PDF", "Adobe Acrobat (pdf)");
                _fileType.Add("ZIP", "ZIP Archive (zip)");
                _fileType.Add("RAR", "RAR Archive (rar)");
                _fileType.Add("WAV", "Wave (wav)");
                _fileType.Add("AVI", "AVI (avi)");
                _fileType.Add("RAM", "Real Audio (ram)");
                _fileType.Add("RM", "Real Media (rm)");
                _fileType.Add("TXT", "文本文件(txt)");
                _fileType.Add("DAT", "数据文件 (dat)");
                _fileType.Add("EXE", "可执行文件 (EXE)");

            }
            return _fileType;
        }
    }//end class
}
