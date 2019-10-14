using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTAUVoiceBankConfig;

namespace oto2dvcfg
{
    class dvcfgCalculator
    {
        #region Variables
        private double offset = 0;
        private bool offsetSetted = false;
        private double consonant = 0;
        private bool consonantSetted = false;
        private double cutoff = 0;
        private bool cutoffSetted = false;
        private double utauPreutterance = 0;
        private bool preutteranceSetted = false;
        private double overlap = 0;
        private bool overlapSetted = false;
        private double wavTime = 0;
        private bool wavTimeSetted = false;

        private double connectPoint = 0.05999999865889549;
        private double endTime = 0;
        private double deepVocalPreutterance = 0;
        private double startTime = 0;
        private double tailPoint = 0;
        private double vowelEnd = 0;
        private double vowelStart = 0;
        private string srcType = string.Empty;
        #endregion

        #region UTAU variables setting
        public double Offset
        {
            get
            {
                if (offsetSetted) return offset;
                else throw new Exception("Unable to get offset.");
            }
            set
            {
                offset = value;
                offsetSetted = true;
            }
        }
        public double Consonant
        {
            get
            {
                if (consonantSetted) return consonant;
                else throw new Exception("Unable to get consonant.");
            }
            set
            {
                consonant = value;
                consonantSetted = true;
            }
        }
        public double Cutoff
        {
            get
            {
                if (cutoffSetted) return cutoff;
                else throw new Exception("Unable to get cutoff.");
            }
            set
            {
                cutoff = value;
                cutoffSetted = true;
            }
        }
        public double UTAUPreutterance
        {
            get
            {
                if (preutteranceSetted) return utauPreutterance;
                else throw new Exception("Unable to get preuttrance.");
            }
            set
            {
                utauPreutterance = value;
                preutteranceSetted = true;
            }
        }
        public double Overlap
        {
            get
            {
                if (overlapSetted) return overlap;
                else throw new Exception("Unable to get overlap.");
            }
            set
            {
                overlap = value;
                overlapSetted = true;
            }
        }

        public double WavTime
        {
            get
            {
                if (wavTimeSetted) return wavTime;
                else throw new Exception("Unable to get wav time.");
            }
            set
            {
                wavTime = value;
                wavTimeSetted = true;
            }
        }
        public string SrcType
        {
            get
            {
                if (string.IsNullOrEmpty(srcType)) throw new Exception("Unable to get src type.");
                return srcType;
            }
            set
            {
                srcType = value;
            }
        }
        #endregion

        #region DeepVocal variables calculation
        public double ConnectPoint
        {
            get
            {
                return connectPoint;
            }
        }
        public double EndTime
        {
            get
            {
                if (!offsetSetted | !cutoffSetted | string.IsNullOrEmpty(srcType))
                    throw new Exception("Variable exception");

                switch (srcType)
                {
                    case "CV":
                        return 0;
                    case "VX":
                        if (cutoff < 0) return offset / 1000 - cutoff / 1000 + connectPoint;
                        else return wavTime / 1000 - offset / 1000 - cutoff / 1000 + connectPoint;
                    case "INDIE":
                        return 0;
                    default:
                        throw new Exception("Unable to parse src type");
                }
            }
            set
            {
                endTime = value;
            }
        }
        public double DVPreuttrance
        {
            get
            {
                if(!preutteranceSetted | !overlapSetted | string.IsNullOrEmpty(srcType)) 
                    throw new Exception("Variable exception");
                switch (srcType)
                {
                    case "CV":
                        if (utauPreutterance == overlap) return utauPreutterance / 1000 + 0.06 + connectPoint;
                        else return utauPreutterance / 1000 + 0.06;
                    case "VX":
                        throw new Exception("Preuttrance is not avilable in VX");
                    case "INDIE":
                        throw new Exception("Preuttrance is not avilable in INDIE");
                    default:
                        throw new Exception("Unable to parse src type");
                }
            }
            set
            {
                deepVocalPreutterance = value;
            }
        }
        public double StartTime
        {
            get
            {
                if(!offsetSetted | !overlapSetted | !preutteranceSetted | string.IsNullOrEmpty(srcType))
                    throw new Exception("Variable exception");
                switch (srcType)
                {
                    case "CV":
                        if (utauPreutterance == overlap) return offset / 1000 - 0.06 - connectPoint;
                        else return offset / 1000 - 0.06;
                    case "VX":
                        return offset / 1000 + overlap / 1000 - 0.06;
                    case "INDIE":
                        return offset / 1000 - connectPoint;
                    default:
                        throw new Exception("Unable to parse src type");
                }
            }
            set
            {
                startTime = value;
            }
        }
        public double TailPoint
        {
            get
            {
                if (!cutoffSetted || !overlapSetted || !preutteranceSetted || !consonantSetted || !wavTimeSetted)
                {
                    throw new Exception("Variable exception");
                }
                switch (srcType)
                {
                    case "CV":
                        if (cutoff < 0)
                        {
                            if (utauPreutterance == overlap) return -cutoff / 1000 - Overlap / 1000 + 0.115 + connectPoint;
                            else return -cutoff / 1000 - Overlap / 1000 + 0.115;
                        }
                        else
                        {
                            if (utauPreutterance == overlap) return wavTime / 1000 - offset / 1000 - cutoff / 1000 + 0.115 + connectPoint;
                            else return wavTime / 1000 - offset / 1000 - cutoff / 1000 + 0.115;
                        }
                    case "VX":
                        return consonant / 1000 - Overlap / 1000 + 0.06;
                    case "INDIE":
                        throw new Exception("VowelEnd is not avilable in INDIE");
                    default:
                        throw new Exception("Unable to parse src type");
                }
            }
            set
            {
                tailPoint = value;
            }
        }
        public double VowelEnd
        {
            get
            {
                if (!cutoffSetted | !preutteranceSetted | !overlapSetted | string.IsNullOrEmpty(srcType))
                    throw new Exception("Variable exception");
                switch (srcType)
                {
                    case "CV":
                        if (cutoff < 0)
                        {
                            if (utauPreutterance == overlap) return -cutoff / 1000 - Overlap / 1000 + 0.06 + connectPoint;
                            else return -cutoff / 1000 - overlap / 1000 + 0.06;
                        }
                        else
                        {
                            if (utauPreutterance == overlap) return wavTime / 1000 - offset / 1000 - cutoff / 1000 + 0.06 + connectPoint;
                            else return wavTime / 1000 - offset / 1000 - cutoff / 1000 + 0.06;
                        }
                    case "VX":
                        throw new Exception("VowelEnd is not avilable in VX");
                    case "INDIE":
                        if (cutoff < 0)
                        {
                            if (utauPreutterance == overlap) return -cutoff / 1000 - Overlap / 1000 + 0.06 + connectPoint;
                            else return -cutoff / 1000 - overlap / 1000 + 0.06;
                        }
                        else
                        {
                            if (utauPreutterance == overlap) return wavTime / 1000 - offset / 1000 - cutoff / 1000 + 0.06 + connectPoint;
                            else return wavTime / 1000 - offset / 1000 - cutoff / 1000 + 0.06;
                        }
                    default:
                        throw new Exception("Unable to parse src type");
                }
            }
            set
            {
                vowelEnd = value;
            }
        }
        public double VowelStart
        {
            get
            {
                if (!consonantSetted | string.IsNullOrEmpty(srcType))
                    throw new Exception("Variable exception");
                switch (srcType)
                {
                    case "CV":
                        if (utauPreutterance == overlap) return consonant / 1000 + 0.06 + connectPoint;
                        else return consonant / 1000 + 0.06;
                    case "VX":
                        throw new Exception("VowelStart is not avilable in VX");
                    case "INDIE":
                        throw new Exception("VowelStart is not avilable in INDIE");
                    default:
                        throw new Exception("Unable to parse src type");
                }
            }
            set
            {
                vowelStart = value;
            }
        }
        #endregion

        public string UpdateTime
        {
            get
            {
                DateTime updateTime = DateTime.Now;
                return updateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public string ToString (double input)
        {
            if (input > 1)
            {
                return input.ToString("F15").Replace("\n", "").Replace("\r", "").Replace("\t", "");
            }
            else
            {
                return input.ToString("F16").Replace("\n", "").Replace("\r", "").Replace("\t", "");
            }
        }
        public string StartNoteDetact(string input)
        {
            if (input.Contains(" ") && input.IndexOf("-") == 0) return input.Replace(" ", "");
            else return input;
        }
        /// <summary>
        /// Clear all variable.
        /// </summary>
        public void Clear()
        {
            offset = 0;
            offsetSetted = false;
            consonant = 0;
            consonantSetted = false;
            cutoff = 0;
            cutoffSetted = false;
            utauPreutterance = 0;
            preutteranceSetted = false;
            overlap = 0;
            overlapSetted = false;
            wavTime = 0;
            wavTimeSetted = false;

            connectPoint = 0.05999999865889549;
            endTime = 0;
            deepVocalPreutterance = 0;
            startTime = 0;
            tailPoint = 0;
            vowelEnd = 0;
            vowelStart = 0;
        }
        /// <summary>
        /// Reset all variable.
        /// </summary>
        public void Reset()
        {
            Clear();
        }
    }
}
