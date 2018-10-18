﻿using System;

namespace Mmu.Mlazh.TfsProxy.Application.Infrastructure.Settings.TfsSettings.Services.Implementation
{
    public class TfsSettingsProvider : ITfsSettingsProvider
    {
        public Models.TfsSettings ProvideTfsSettings()
        {
            return new Models.TfsSettings
            {
                TfsBaseOrganisationPath = new Uri("https://drmueller.visualstudio.com/"),
                TfsProjectName = "Fun%20Project",
                BasicAuthToken = "fmhkiljkf4ytev5werumffujgs7ofczm7x5kinwghta7kddpdlpq"
            };
        }
    }
}