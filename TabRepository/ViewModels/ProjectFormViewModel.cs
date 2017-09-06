﻿using TabRepository.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TabRepository.ViewModels
{
    public class ProjectFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }

        public ProjectFormViewModel()
        {
            Id = 0;
        }

        public ProjectFormViewModel(Project project)
        {
            Id = project.Id;
            Name = project.Name;
            Description = project.Description;
        }
    }
}