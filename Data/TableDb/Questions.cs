using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa.Data.TableDb
{
    public class Questions
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Question { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Answer { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string QuestionEn { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AnswerEn { get; set; }
        public bool IsActive { get; set; }
    }
}
