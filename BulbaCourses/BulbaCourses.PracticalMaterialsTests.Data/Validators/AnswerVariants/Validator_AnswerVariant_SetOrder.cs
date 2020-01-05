﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTests.Data.Models.AnswerVariants;
using FluentValidation;

namespace BulbaCourses.PracticalMaterialsTests.Data.Validators.AnswerVariants
{
    public class Validator_AnswerVariant_SetOrder : AbstractValidator<MAnswerVariant_SetOrderDb>
    {
        public Validator_AnswerVariant_SetOrder()
        {
            RuleFor(x => x.AnswerText)
                //.Cascade(CascadeMode.StopOnFirstFailure)                
                .Length(20, 50)
                .WithMessage("Длина QuestionText должна быть от 20 до 50 символов")
                .Must(x => !x.All(Char.IsDigit)).WithMessage("Наименование не может быть только из цифр")
                .Must(x => !x.All(Char.IsSymbol)).WithMessage("Наименование не может быть только из символов")
                .Must(x => !String.IsNullOrWhiteSpace(x)).WithMessage("Наименование не может быть только из пробелов");
        }
    }
}
