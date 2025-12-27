using System;
using adamaddison.Models;

namespace adamaddison.View_Models;

public class ExperienceViewModel
{
    public string[] SkillsList { get; set; } = [];
    public string[] TrainingList { get; set; } = [];
    public CertificationInfo AZ204Certification = new();
}