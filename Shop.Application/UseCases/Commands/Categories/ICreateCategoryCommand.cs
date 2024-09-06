﻿using Shop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.UseCases.Commands.Categories
{
    public interface ICreateCategoryCommand : ICommand<CreateCategoryDTO>
    {
    }
}
