ALTER TABLE [edfi].[StudentOtherName] ADD StudentOtherNameIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentOtherNameIdentity on [edfi].[StudentOtherName] (StudentOtherNameIdentity)

ALTER TABLE [edfi].[CohortProgram] ADD CohortProgramIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CohortProgramIdentity on [edfi].[CohortProgram] (CohortProgramIdentity)

ALTER TABLE [edfi].[StaffCredential] ADD StaffCredentialIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffCredentialIdentity on [edfi].[StaffCredential] (StaffCredentialIdentity)

ALTER TABLE [edfi].[InterventionStudyAppropriateSex] ADD InterventionStudyAppropriateSexIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionStudyAppropriateSexIdentity on [edfi].[InterventionStudyAppropriateSex] (InterventionStudyAppropriateSexIdentity)

ALTER TABLE [edfi].[StudentParentAssociation] ADD StudentParentAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentParentAssociationIdentity on [edfi].[StudentParentAssociation] (StudentParentAssociationIdentity)

ALTER TABLE [edfi].[StaffEducationOrganizationAssignmentAssociation] ADD StaffEducationOrganizationAssignmentAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffEducationOrganizationAssignmentAssociationIdentity on [edfi].[StaffEducationOrganizationAssignmentAssociation] (StaffEducationOrganizationAssignmentAssociationIdentity)

ALTER TABLE [edfi].[Program] ADD ProgramIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ProgramIdentity on [edfi].[Program] (ProgramIdentity)

ALTER TABLE [edfi].[InterventionStudyEducationContent] ADD InterventionStudyEducationContentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionStudyEducationContentIdentity on [edfi].[InterventionStudyEducationContent] (InterventionStudyEducationContentIdentity)

ALTER TABLE [edfi].[EducationOrganizationIdentificationCode] ADD EducationOrganizationIdentificationCodeIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationOrganizationIdentificationCodeIdentity on [edfi].[EducationOrganizationIdentificationCode] (EducationOrganizationIdentificationCodeIdentity)

ALTER TABLE [edfi].[StaffEducationOrganizationEmploymentAssociation] ADD StaffEducationOrganizationEmploymentAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffEducationOrganizationEmploymentAssociationIdentity on [edfi].[StaffEducationOrganizationEmploymentAssociation] (StaffEducationOrganizationEmploymentAssociationIdentity)

ALTER TABLE [edfi].[InterventionStudyInterventionEffectiveness] ADD InterventionStudyInterventionEffectivenessIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionStudyInterventionEffectivenessIdentity on [edfi].[InterventionStudyInterventionEffectiveness] (InterventionStudyInterventionEffectivenessIdentity)

ALTER TABLE [edfi].[StudentProgramAssociation] ADD StudentProgramAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentProgramAssociationIdentity on [edfi].[StudentProgramAssociation] (StudentProgramAssociationIdentity)

ALTER TABLE [edfi].[StaffElectronicMail] ADD StaffElectronicMailIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffElectronicMailIdentity on [edfi].[StaffElectronicMail] (StaffElectronicMailIdentity)

ALTER TABLE [edfi].[InterventionStudyLearningResourceMetadataURI] ADD InterventionStudyLearningResourceMetadataURIIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionStudyLearningResourceMetadataURIIdentity on [edfi].[InterventionStudyLearningResourceMetadataURI] (InterventionStudyLearningResourceMetadataURIIdentity)

ALTER TABLE [edfi].[EducationOrganizationInstitutionTelephone] ADD EducationOrganizationInstitutionTelephoneIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationOrganizationInstitutionTelephoneIdentity on [edfi].[EducationOrganizationInstitutionTelephone] (EducationOrganizationInstitutionTelephoneIdentity)

ALTER TABLE [edfi].[StudentProgramAssociationService] ADD StudentProgramAssociationServiceIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentProgramAssociationServiceIdentity on [edfi].[StudentProgramAssociationService] (StudentProgramAssociationServiceIdentity)

ALTER TABLE [edfi].[StaffIdentificationCode] ADD StaffIdentificationCodeIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffIdentificationCodeIdentity on [edfi].[StaffIdentificationCode] (StaffIdentificationCodeIdentity)

ALTER TABLE [edfi].[ProgramCharacteristic] ADD ProgramCharacteristicIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ProgramCharacteristicIdentity on [edfi].[ProgramCharacteristic] (ProgramCharacteristicIdentity)

ALTER TABLE [edfi].[InterventionStudyPopulationServed] ADD InterventionStudyPopulationServedIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionStudyPopulationServedIdentity on [edfi].[InterventionStudyPopulationServed] (InterventionStudyPopulationServedIdentity)

ALTER TABLE [edfi].[EducationOrganizationInternationalAddress] ADD EducationOrganizationInternationalAddressIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationOrganizationInternationalAddressIdentity on [edfi].[EducationOrganizationInternationalAddress] (EducationOrganizationInternationalAddressIdentity)

ALTER TABLE [edfi].[StudentProgramAttendanceEvent] ADD StudentProgramAttendanceEventIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentProgramAttendanceEventIdentity on [edfi].[StudentProgramAttendanceEvent] (StudentProgramAttendanceEventIdentity)

ALTER TABLE [edfi].[CompetencyObjective] ADD CompetencyObjectiveIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CompetencyObjectiveIdentity on [edfi].[CompetencyObjective] (CompetencyObjectiveIdentity)

ALTER TABLE [edfi].[StaffIdentificationDocument] ADD StaffIdentificationDocumentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffIdentificationDocumentIdentity on [edfi].[StaffIdentificationDocument] (StaffIdentificationDocumentIdentity)

ALTER TABLE [edfi].[InterventionStudyStateAbbreviation] ADD InterventionStudyStateAbbreviationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionStudyStateAbbreviationIdentity on [edfi].[InterventionStudyStateAbbreviation] (InterventionStudyStateAbbreviationIdentity)

ALTER TABLE [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ADD EducationOrganizationInterventionPrescriptionAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationOrganizationInterventionPrescriptionAssociationIdentity on [edfi].[EducationOrganizationInterventionPrescriptionAssociation] (EducationOrganizationInterventionPrescriptionAssociationIdentity)

ALTER TABLE [edfi].[StudentProgramParticipation] ADD StudentProgramParticipationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentProgramParticipationIdentity on [edfi].[StudentProgramParticipation] (StudentProgramParticipationIdentity)

ALTER TABLE [edfi].[InterventionStudyURI] ADD InterventionStudyURIIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionStudyURIIdentity on [edfi].[InterventionStudyURI] (InterventionStudyURIIdentity)

ALTER TABLE [edfi].[EducationOrganizationNetwork] ADD EducationOrganizationNetworkIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationOrganizationNetworkIdentity on [edfi].[EducationOrganizationNetwork] (EducationOrganizationNetworkIdentity)

ALTER TABLE [edfi].[StudentProgramParticipationProgramCharacteristic] ADD StudentProgramParticipationProgramCharacteristicIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentProgramParticipationProgramCharacteristicIdentity on [edfi].[StudentProgramParticipationProgramCharacteristic] (StudentProgramParticipationProgramCharacteristicIdentity)

ALTER TABLE [edfi].[StaffInternationalAddress] ADD StaffInternationalAddressIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffInternationalAddressIdentity on [edfi].[StaffInternationalAddress] (StaffInternationalAddressIdentity)

ALTER TABLE [edfi].[ProgramLearningObjective] ADD ProgramLearningObjectiveIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ProgramLearningObjectiveIdentity on [edfi].[ProgramLearningObjective] (ProgramLearningObjectiveIdentity)

ALTER TABLE [edfi].[InterventionURI] ADD InterventionURIIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionURIIdentity on [edfi].[InterventionURI] (InterventionURIIdentity)

ALTER TABLE [edfi].[EducationOrganizationNetworkAssociation] ADD EducationOrganizationNetworkAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationOrganizationNetworkAssociationIdentity on [edfi].[EducationOrganizationNetworkAssociation] (EducationOrganizationNetworkAssociationIdentity)

ALTER TABLE [edfi].[StudentRace] ADD StudentRaceIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentRaceIdentity on [edfi].[StudentRace] (StudentRaceIdentity)

ALTER TABLE [edfi].[StaffLanguage] ADD StaffLanguageIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffLanguageIdentity on [edfi].[StaffLanguage] (StaffLanguageIdentity)

ALTER TABLE [edfi].[ProgramLearningStandard] ADD ProgramLearningStandardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ProgramLearningStandardIdentity on [edfi].[ProgramLearningStandard] (ProgramLearningStandardIdentity)

ALTER TABLE [edfi].[EducationOrganizationPeerAssociation] ADD EducationOrganizationPeerAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationOrganizationPeerAssociationIdentity on [edfi].[EducationOrganizationPeerAssociation] (EducationOrganizationPeerAssociationIdentity)

ALTER TABLE [edfi].[StudentSchoolAssociation] ADD StudentSchoolAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentSchoolAssociationIdentity on [edfi].[StudentSchoolAssociation] (StudentSchoolAssociationIdentity)

ALTER TABLE [edfi].[ContractedStaff] ADD ContractedStaffIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ContractedStaffIdentity on [edfi].[ContractedStaff] (ContractedStaffIdentity)

ALTER TABLE [edfi].[StaffLanguageUse] ADD StaffLanguageUseIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffLanguageUseIdentity on [edfi].[StaffLanguageUse] (StaffLanguageUseIdentity)

ALTER TABLE [edfi].[ProgramService] ADD ProgramServiceIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ProgramServiceIdentity on [edfi].[ProgramService] (ProgramServiceIdentity)

ALTER TABLE [edfi].[StudentSchoolAssociationEducationPlan] ADD StudentSchoolAssociationEducationPlanIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentSchoolAssociationEducationPlanIdentity on [edfi].[StudentSchoolAssociationEducationPlan] (StudentSchoolAssociationEducationPlanIdentity)

ALTER TABLE [edfi].[StaffOtherName] ADD StaffOtherNameIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffOtherNameIdentity on [edfi].[StaffOtherName] (StaffOtherNameIdentity)

ALTER TABLE [edfi].[EducationServiceCenter] ADD EducationServiceCenterIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationServiceCenterIdentity on [edfi].[EducationServiceCenter] (EducationServiceCenterIdentity)

ALTER TABLE [edfi].[StudentSchoolAttendanceEvent] ADD StudentSchoolAttendanceEventIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentSchoolAttendanceEventIdentity on [edfi].[StudentSchoolAttendanceEvent] (StudentSchoolAttendanceEventIdentity)

ALTER TABLE [edfi].[StaffProgramAssociation] ADD StaffProgramAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffProgramAssociationIdentity on [edfi].[StaffProgramAssociation] (StaffProgramAssociationIdentity)

ALTER TABLE [edfi].[AcademicWeek] ADD AcademicWeekIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AcademicWeekIdentity on [edfi].[AcademicWeek] (AcademicWeekIdentity)

ALTER TABLE [edfi].[LearningObjective] ADD LearningObjectiveIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LearningObjectiveIdentity on [edfi].[LearningObjective] (LearningObjectiveIdentity)

ALTER TABLE [edfi].[StudentSectionAssociation] ADD StudentSectionAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentSectionAssociationIdentity on [edfi].[StudentSectionAssociation] (StudentSectionAssociationIdentity)

ALTER TABLE [edfi].[StaffRace] ADD StaffRaceIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffRaceIdentity on [edfi].[StaffRace] (StaffRaceIdentity)

ALTER TABLE [edfi].[LearningObjectiveContentStandard] ADD LearningObjectiveContentStandardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LearningObjectiveContentStandardIdentity on [edfi].[LearningObjectiveContentStandard] (LearningObjectiveContentStandardIdentity)

ALTER TABLE [edfi].[StudentSectionAttendanceEvent] ADD StudentSectionAttendanceEventIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentSectionAttendanceEventIdentity on [edfi].[StudentSectionAttendanceEvent] (StudentSectionAttendanceEventIdentity)

ALTER TABLE [edfi].[Course] ADD CourseIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CourseIdentity on [edfi].[Course] (CourseIdentity)

ALTER TABLE [edfi].[StaffSchoolAssociation] ADD StaffSchoolAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffSchoolAssociationIdentity on [edfi].[StaffSchoolAssociation] (StaffSchoolAssociationIdentity)

ALTER TABLE [edfi].[LearningObjectiveContentStandardAuthor] ADD LearningObjectiveContentStandardAuthorIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LearningObjectiveContentStandardAuthorIdentity on [edfi].[LearningObjectiveContentStandardAuthor] (LearningObjectiveContentStandardAuthorIdentity)

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociation] ADD StudentSpecialEducationProgramAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentSpecialEducationProgramAssociationIdentity on [edfi].[StudentSpecialEducationProgramAssociation] (StudentSpecialEducationProgramAssociationIdentity)

ALTER TABLE [edfi].[StaffSchoolAssociationAcademicSubject] ADD StaffSchoolAssociationAcademicSubjectIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffSchoolAssociationAcademicSubjectIdentity on [edfi].[StaffSchoolAssociationAcademicSubject] (StaffSchoolAssociationAcademicSubjectIdentity)

ALTER TABLE [edfi].[Account] ADD AccountIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AccountIdentity on [edfi].[Account] (AccountIdentity)

ALTER TABLE [edfi].[LearningObjectiveLearningStandard] ADD LearningObjectiveLearningStandardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LearningObjectiveLearningStandardIdentity on [edfi].[LearningObjectiveLearningStandard] (LearningObjectiveLearningStandardIdentity)

ALTER TABLE [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] ADD StudentSpecialEducationProgramAssociationServiceProviderIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentSpecialEducationProgramAssociationServiceProviderIdentity on [edfi].[StudentSpecialEducationProgramAssociationServiceProvider] (StudentSpecialEducationProgramAssociationServiceProviderIdentity)

ALTER TABLE [edfi].[StaffSchoolAssociationGradeLevel] ADD StaffSchoolAssociationGradeLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffSchoolAssociationGradeLevelIdentity on [edfi].[StaffSchoolAssociationGradeLevel] (StaffSchoolAssociationGradeLevelIdentity)

ALTER TABLE [edfi].[AccountabilityRating] ADD AccountabilityRatingIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AccountabilityRatingIdentity on [edfi].[AccountabilityRating] (AccountabilityRatingIdentity)

ALTER TABLE [edfi].[LearningStandard] ADD LearningStandardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LearningStandardIdentity on [edfi].[LearningStandard] (LearningStandardIdentity)

ALTER TABLE [edfi].[StudentTelephone] ADD StudentTelephoneIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentTelephoneIdentity on [edfi].[StudentTelephone] (StudentTelephoneIdentity)

ALTER TABLE [edfi].[CourseCompetencyLevel] ADD CourseCompetencyLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CourseCompetencyLevelIdentity on [edfi].[CourseCompetencyLevel] (CourseCompetencyLevelIdentity)

ALTER TABLE [edfi].[StaffSectionAssociation] ADD StaffSectionAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffSectionAssociationIdentity on [edfi].[StaffSectionAssociation] (StaffSectionAssociationIdentity)

ALTER TABLE [edfi].[AccountCode] ADD AccountCodeIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AccountCodeIdentity on [edfi].[AccountCode] (AccountCodeIdentity)

ALTER TABLE [edfi].[LearningStandardContentStandard] ADD LearningStandardContentStandardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LearningStandardContentStandardIdentity on [edfi].[LearningStandardContentStandard] (LearningStandardContentStandardIdentity)

ALTER TABLE [edfi].[StudentTitleIPartAProgramAssociation] ADD StudentTitleIPartAProgramAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentTitleIPartAProgramAssociationIdentity on [edfi].[StudentTitleIPartAProgramAssociation] (StudentTitleIPartAProgramAssociationIdentity)

ALTER TABLE [edfi].[StaffTelephone] ADD StaffTelephoneIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffTelephoneIdentity on [edfi].[StaffTelephone] (StaffTelephoneIdentity)

ALTER TABLE [edfi].[LearningStandardContentStandardAuthor] ADD LearningStandardContentStandardAuthorIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LearningStandardContentStandardAuthorIdentity on [edfi].[LearningStandardContentStandardAuthor] (LearningStandardContentStandardAuthorIdentity)

ALTER TABLE [edfi].[StudentVisa] ADD StudentVisaIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentVisaIdentity on [edfi].[StudentVisa] (StudentVisaIdentity)

ALTER TABLE [edfi].[StaffVisa] ADD StaffVisaIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffVisaIdentity on [edfi].[StaffVisa] (StaffVisaIdentity)

ALTER TABLE [edfi].[LearningStandardIdentificationCode] ADD LearningStandardIdentificationCodeIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LearningStandardIdentificationCodeIdentity on [edfi].[LearningStandardIdentificationCode] (LearningStandardIdentificationCodeIdentity)

ALTER TABLE [edfi].[CourseGradeLevel] ADD CourseGradeLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CourseGradeLevelIdentity on [edfi].[CourseGradeLevel] (CourseGradeLevelIdentity)

ALTER TABLE [edfi].[LearningStandardPrerequisiteLearningStandard] ADD LearningStandardPrerequisiteLearningStandardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LearningStandardPrerequisiteLearningStandardIdentity on [edfi].[LearningStandardPrerequisiteLearningStandard] (LearningStandardPrerequisiteLearningStandardIdentity)

ALTER TABLE [edfi].[CourseIdentificationCode] ADD CourseIdentificationCodeIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CourseIdentificationCodeIdentity on [edfi].[CourseIdentificationCode] (CourseIdentificationCodeIdentity)

ALTER TABLE [edfi].[StateEducationAgency] ADD StateEducationAgencyIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StateEducationAgencyIdentity on [edfi].[StateEducationAgency] (StateEducationAgencyIdentity)

ALTER TABLE [edfi].[Actual] ADD ActualIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ActualIdentity on [edfi].[Actual] (ActualIdentity)

ALTER TABLE [edfi].[ReportCard] ADD ReportCardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ReportCardIdentity on [edfi].[ReportCard] (ReportCardIdentity)

ALTER TABLE [edfi].[LeaveEvent] ADD LeaveEventIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LeaveEventIdentity on [edfi].[LeaveEvent] (LeaveEventIdentity)

ALTER TABLE [edfi].[FeederSchoolAssociation] ADD FeederSchoolAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_FeederSchoolAssociationIdentity on [edfi].[FeederSchoolAssociation] (FeederSchoolAssociationIdentity)

ALTER TABLE [edfi].[CourseLearningObjective] ADD CourseLearningObjectiveIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CourseLearningObjectiveIdentity on [edfi].[CourseLearningObjective] (CourseLearningObjectiveIdentity)

ALTER TABLE [edfi].[StateEducationAgencyAccountability] ADD StateEducationAgencyAccountabilityIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StateEducationAgencyAccountabilityIdentity on [edfi].[StateEducationAgencyAccountability] (StateEducationAgencyAccountabilityIdentity)

ALTER TABLE [edfi].[ReportCardGrade] ADD ReportCardGradeIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ReportCardGradeIdentity on [edfi].[ReportCardGrade] (ReportCardGradeIdentity)

ALTER TABLE [edfi].[Grade] ADD GradeIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_GradeIdentity on [edfi].[Grade] (GradeIdentity)

ALTER TABLE [edfi].[CourseLearningStandard] ADD CourseLearningStandardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CourseLearningStandardIdentity on [edfi].[CourseLearningStandard] (CourseLearningStandardIdentity)

ALTER TABLE [edfi].[StateEducationAgencyFederalFunds] ADD StateEducationAgencyFederalFundsIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StateEducationAgencyFederalFundsIdentity on [edfi].[StateEducationAgencyFederalFunds] (StateEducationAgencyFederalFundsIdentity)

ALTER TABLE [edfi].[ReportCardStudentCompetencyObjective] ADD ReportCardStudentCompetencyObjectiveIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ReportCardStudentCompetencyObjectiveIdentity on [edfi].[ReportCardStudentCompetencyObjective] (ReportCardStudentCompetencyObjectiveIdentity)

ALTER TABLE [edfi].[GradebookEntry] ADD GradebookEntryIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_GradebookEntryIdentity on [edfi].[GradebookEntry] (GradebookEntryIdentity)

ALTER TABLE [edfi].[CourseLevelCharacteristic] ADD CourseLevelCharacteristicIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CourseLevelCharacteristicIdentity on [edfi].[CourseLevelCharacteristic] (CourseLevelCharacteristicIdentity)

ALTER TABLE [edfi].[ReportCardStudentLearningObjective] ADD ReportCardStudentLearningObjectiveIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ReportCardStudentLearningObjectiveIdentity on [edfi].[ReportCardStudentLearningObjective] (ReportCardStudentLearningObjectiveIdentity)

ALTER TABLE [edfi].[LevelDescriptorGradeLevel] ADD LevelDescriptorGradeLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LevelDescriptorGradeLevelIdentity on [edfi].[LevelDescriptorGradeLevel] (LevelDescriptorGradeLevelIdentity)

ALTER TABLE [edfi].[GradebookEntryLearningObjective] ADD GradebookEntryLearningObjectiveIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_GradebookEntryLearningObjectiveIdentity on [edfi].[GradebookEntryLearningObjective] (GradebookEntryLearningObjectiveIdentity)

ALTER TABLE [edfi].[StudentAcademicRecord] ADD StudentAcademicRecordIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAcademicRecordIdentity on [edfi].[StudentAcademicRecord] (StudentAcademicRecordIdentity)

ALTER TABLE [edfi].[GradebookEntryLearningStandard] ADD GradebookEntryLearningStandardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_GradebookEntryLearningStandardIdentity on [edfi].[GradebookEntryLearningStandard] (GradebookEntryLearningStandardIdentity)

ALTER TABLE [edfi].[CourseOffering] ADD CourseOfferingIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CourseOfferingIdentity on [edfi].[CourseOffering] (CourseOfferingIdentity)

ALTER TABLE [edfi].[StudentAcademicRecordAcademicHonor] ADD StudentAcademicRecordAcademicHonorIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAcademicRecordAcademicHonorIdentity on [edfi].[StudentAcademicRecordAcademicHonor] (StudentAcademicRecordAcademicHonorIdentity)

ALTER TABLE [edfi].[CourseOfferingCurriculumUsed] ADD CourseOfferingCurriculumUsedIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CourseOfferingCurriculumUsedIdentity on [edfi].[CourseOfferingCurriculumUsed] (CourseOfferingCurriculumUsedIdentity)

ALTER TABLE [edfi].[StudentAcademicRecordClassRanking] ADD StudentAcademicRecordClassRankingIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAcademicRecordClassRankingIdentity on [edfi].[StudentAcademicRecordClassRanking] (StudentAcademicRecordClassRankingIdentity)

ALTER TABLE [edfi].[Assessment] ADD AssessmentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentIdentity on [edfi].[Assessment] (AssessmentIdentity)

ALTER TABLE [edfi].[StudentAcademicRecordDiploma] ADD StudentAcademicRecordDiplomaIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAcademicRecordDiplomaIdentity on [edfi].[StudentAcademicRecordDiploma] (StudentAcademicRecordDiplomaIdentity)

ALTER TABLE [edfi].[CourseTranscript] ADD CourseTranscriptIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CourseTranscriptIdentity on [edfi].[CourseTranscript] (CourseTranscriptIdentity)

ALTER TABLE [edfi].[StudentAcademicRecordRecognition] ADD StudentAcademicRecordRecognitionIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAcademicRecordRecognitionIdentity on [edfi].[StudentAcademicRecordRecognition] (StudentAcademicRecordRecognitionIdentity)

ALTER TABLE [edfi].[AssessmentContentStandard] ADD AssessmentContentStandardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentContentStandardIdentity on [edfi].[AssessmentContentStandard] (AssessmentContentStandardIdentity)

ALTER TABLE [edfi].[LocalEducationAgency] ADD LocalEducationAgencyIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LocalEducationAgencyIdentity on [edfi].[LocalEducationAgency] (LocalEducationAgencyIdentity)

ALTER TABLE [edfi].[CourseTranscriptAdditionalCredit] ADD CourseTranscriptAdditionalCreditIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CourseTranscriptAdditionalCreditIdentity on [edfi].[CourseTranscriptAdditionalCredit] (CourseTranscriptAdditionalCreditIdentity)

ALTER TABLE [edfi].[StudentAcademicRecordReportCard] ADD StudentAcademicRecordReportCardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAcademicRecordReportCardIdentity on [edfi].[StudentAcademicRecordReportCard] (StudentAcademicRecordReportCardIdentity)

ALTER TABLE [edfi].[AssessmentContentStandardAuthor] ADD AssessmentContentStandardAuthorIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentContentStandardAuthorIdentity on [edfi].[AssessmentContentStandardAuthor] (AssessmentContentStandardAuthorIdentity)

ALTER TABLE [edfi].[LocalEducationAgencyAccountability] ADD LocalEducationAgencyAccountabilityIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LocalEducationAgencyAccountabilityIdentity on [edfi].[LocalEducationAgencyAccountability] (LocalEducationAgencyAccountabilityIdentity)

ALTER TABLE [edfi].[GradingPeriod] ADD GradingPeriodIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_GradingPeriodIdentity on [edfi].[GradingPeriod] (GradingPeriodIdentity)

ALTER TABLE [edfi].[CourseTranscriptExternalCourse] ADD CourseTranscriptExternalCourseIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CourseTranscriptExternalCourseIdentity on [edfi].[CourseTranscriptExternalCourse] (CourseTranscriptExternalCourseIdentity)

ALTER TABLE [edfi].[StudentAddress] ADD StudentAddressIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAddressIdentity on [edfi].[StudentAddress] (StudentAddressIdentity)

ALTER TABLE [edfi].[AssessmentFamily] ADD AssessmentFamilyIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentFamilyIdentity on [edfi].[AssessmentFamily] (AssessmentFamilyIdentity)

ALTER TABLE [edfi].[StudentAssessment] ADD StudentAssessmentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAssessmentIdentity on [edfi].[StudentAssessment] (StudentAssessmentIdentity)

ALTER TABLE [edfi].[AssessmentFamilyAssessmentPeriod] ADD AssessmentFamilyAssessmentPeriodIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentFamilyAssessmentPeriodIdentity on [edfi].[AssessmentFamilyAssessmentPeriod] (AssessmentFamilyAssessmentPeriodIdentity)

ALTER TABLE [edfi].[RestraintEvent] ADD RestraintEventIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_RestraintEventIdentity on [edfi].[RestraintEvent] (RestraintEventIdentity)

ALTER TABLE [edfi].[LocalEducationAgencyFederalFunds] ADD LocalEducationAgencyFederalFundsIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LocalEducationAgencyFederalFundsIdentity on [edfi].[LocalEducationAgencyFederalFunds] (LocalEducationAgencyFederalFundsIdentity)

ALTER TABLE [edfi].[StudentAssessmentAccommodation] ADD StudentAssessmentAccommodationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAssessmentAccommodationIdentity on [edfi].[StudentAssessmentAccommodation] (StudentAssessmentAccommodationIdentity)

ALTER TABLE [edfi].[AssessmentFamilyContentStandard] ADD AssessmentFamilyContentStandardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentFamilyContentStandardIdentity on [edfi].[AssessmentFamilyContentStandard] (AssessmentFamilyContentStandardIdentity)

ALTER TABLE [edfi].[RestraintEventProgram] ADD RestraintEventProgramIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_RestraintEventProgramIdentity on [edfi].[RestraintEventProgram] (RestraintEventProgramIdentity)

ALTER TABLE [edfi].[Location] ADD LocationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_LocationIdentity on [edfi].[Location] (LocationIdentity)

ALTER TABLE [edfi].[GraduationPlan] ADD GraduationPlanIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_GraduationPlanIdentity on [edfi].[GraduationPlan] (GraduationPlanIdentity)

ALTER TABLE [edfi].[StudentAssessmentItem] ADD StudentAssessmentItemIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAssessmentItemIdentity on [edfi].[StudentAssessmentItem] (StudentAssessmentItemIdentity)

ALTER TABLE [edfi].[AssessmentFamilyContentStandardAuthor] ADD AssessmentFamilyContentStandardAuthorIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentFamilyContentStandardAuthorIdentity on [edfi].[AssessmentFamilyContentStandardAuthor] (AssessmentFamilyContentStandardAuthorIdentity)

ALTER TABLE [edfi].[RestraintEventReason] ADD RestraintEventReasonIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_RestraintEventReasonIdentity on [edfi].[RestraintEventReason] (RestraintEventReasonIdentity)

ALTER TABLE [edfi].[GraduationPlanCreditsByCourse] ADD GraduationPlanCreditsByCourseIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_GraduationPlanCreditsByCourseIdentity on [edfi].[GraduationPlanCreditsByCourse] (GraduationPlanCreditsByCourseIdentity)

ALTER TABLE [edfi].[StudentAssessmentPerformanceLevel] ADD StudentAssessmentPerformanceLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAssessmentPerformanceLevelIdentity on [edfi].[StudentAssessmentPerformanceLevel] (StudentAssessmentPerformanceLevelIdentity)

ALTER TABLE [edfi].[AssessmentFamilyIdentificationCode] ADD AssessmentFamilyIdentificationCodeIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentFamilyIdentificationCodeIdentity on [edfi].[AssessmentFamilyIdentificationCode] (AssessmentFamilyIdentificationCodeIdentity)

ALTER TABLE [edfi].[GraduationPlanCreditsByCourseCourse] ADD GraduationPlanCreditsByCourseCourseIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_GraduationPlanCreditsByCourseCourseIdentity on [edfi].[GraduationPlanCreditsByCourseCourse] (GraduationPlanCreditsByCourseCourseIdentity)

ALTER TABLE [edfi].[StudentAssessmentScoreResult] ADD StudentAssessmentScoreResultIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAssessmentScoreResultIdentity on [edfi].[StudentAssessmentScoreResult] (StudentAssessmentScoreResultIdentity)

ALTER TABLE [edfi].[AssessmentFamilyLanguage] ADD AssessmentFamilyLanguageIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentFamilyLanguageIdentity on [edfi].[AssessmentFamilyLanguage] (AssessmentFamilyLanguageIdentity)

ALTER TABLE [edfi].[GraduationPlanCreditsBySubject] ADD GraduationPlanCreditsBySubjectIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_GraduationPlanCreditsBySubjectIdentity on [edfi].[GraduationPlanCreditsBySubject] (GraduationPlanCreditsBySubjectIdentity)

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessment] ADD StudentAssessmentStudentObjectiveAssessmentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAssessmentStudentObjectiveAssessmentIdentity on [edfi].[StudentAssessmentStudentObjectiveAssessment] (StudentAssessmentStudentObjectiveAssessmentIdentity)

ALTER TABLE [edfi].[AssessmentIdentificationCode] ADD AssessmentIdentificationCodeIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentIdentificationCodeIdentity on [edfi].[AssessmentIdentificationCode] (AssessmentIdentificationCodeIdentity)

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] ADD StudentAssessmentStudentObjectiveAssessmentPerformanceLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAssessmentStudentObjectiveAssessmentPerformanceLevelIdentity on [edfi].[StudentAssessmentStudentObjectiveAssessmentPerformanceLevel] (StudentAssessmentStudentObjectiveAssessmentPerformanceLevelIdentity)

ALTER TABLE [edfi].[School] ADD SchoolIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_SchoolIdentity on [edfi].[School] (SchoolIdentity)

ALTER TABLE [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] ADD StudentAssessmentStudentObjectiveAssessmentScoreResultIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentAssessmentStudentObjectiveAssessmentScoreResultIdentity on [edfi].[StudentAssessmentStudentObjectiveAssessmentScoreResult] (StudentAssessmentStudentObjectiveAssessmentScoreResultIdentity)

ALTER TABLE [edfi].[AssessmentItem] ADD AssessmentItemIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentItemIdentity on [edfi].[AssessmentItem] (AssessmentItemIdentity)

ALTER TABLE [edfi].[SchoolCategory] ADD SchoolCategoryIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_SchoolCategoryIdentity on [edfi].[SchoolCategory] (SchoolCategoryIdentity)

ALTER TABLE [edfi].[ObjectiveAssessment] ADD ObjectiveAssessmentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ObjectiveAssessmentIdentity on [edfi].[ObjectiveAssessment] (ObjectiveAssessmentIdentity)

ALTER TABLE [edfi].[StudentCharacteristic] ADD StudentCharacteristicIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentCharacteristicIdentity on [edfi].[StudentCharacteristic] (StudentCharacteristicIdentity)

ALTER TABLE [edfi].[ObjectiveAssessmentAssessmentItem] ADD ObjectiveAssessmentAssessmentItemIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ObjectiveAssessmentAssessmentItemIdentity on [edfi].[ObjectiveAssessmentAssessmentItem] (ObjectiveAssessmentAssessmentItemIdentity)

ALTER TABLE [edfi].[AssessmentItemLearningStandard] ADD AssessmentItemLearningStandardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentItemLearningStandardIdentity on [edfi].[AssessmentItemLearningStandard] (AssessmentItemLearningStandardIdentity)

ALTER TABLE [edfi].[ObjectiveAssessmentLearningObjective] ADD ObjectiveAssessmentLearningObjectiveIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ObjectiveAssessmentLearningObjectiveIdentity on [edfi].[ObjectiveAssessmentLearningObjective] (ObjectiveAssessmentLearningObjectiveIdentity)

ALTER TABLE [edfi].[ObjectiveAssessmentLearningStandard] ADD ObjectiveAssessmentLearningStandardIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ObjectiveAssessmentLearningStandardIdentity on [edfi].[ObjectiveAssessmentLearningStandard] (ObjectiveAssessmentLearningStandardIdentity)

ALTER TABLE [edfi].[StudentCohortAssociation] ADD StudentCohortAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentCohortAssociationIdentity on [edfi].[StudentCohortAssociation] (StudentCohortAssociationIdentity)

ALTER TABLE [edfi].[AssessmentLanguage] ADD AssessmentLanguageIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentLanguageIdentity on [edfi].[AssessmentLanguage] (AssessmentLanguageIdentity)

ALTER TABLE [edfi].[ObjectiveAssessmentPerformanceLevel] ADD ObjectiveAssessmentPerformanceLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ObjectiveAssessmentPerformanceLevelIdentity on [edfi].[ObjectiveAssessmentPerformanceLevel] (ObjectiveAssessmentPerformanceLevelIdentity)

ALTER TABLE [edfi].[StudentCohortAssociationSection] ADD StudentCohortAssociationSectionIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentCohortAssociationSectionIdentity on [edfi].[StudentCohortAssociationSection] (StudentCohortAssociationSectionIdentity)

ALTER TABLE [edfi].[AssessmentPerformanceLevel] ADD AssessmentPerformanceLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentPerformanceLevelIdentity on [edfi].[AssessmentPerformanceLevel] (AssessmentPerformanceLevelIdentity)

ALTER TABLE [edfi].[SchoolGradeLevel] ADD SchoolGradeLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_SchoolGradeLevelIdentity on [edfi].[SchoolGradeLevel] (SchoolGradeLevelIdentity)

ALTER TABLE [edfi].[StudentCohortYear] ADD StudentCohortYearIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentCohortYearIdentity on [edfi].[StudentCohortYear] (StudentCohortYearIdentity)

ALTER TABLE [edfi].[OpenStaffPosition] ADD OpenStaffPositionIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_OpenStaffPositionIdentity on [edfi].[OpenStaffPosition] (OpenStaffPositionIdentity)

ALTER TABLE [edfi].[DisciplineAction] ADD DisciplineActionIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_DisciplineActionIdentity on [edfi].[DisciplineAction] (DisciplineActionIdentity)

ALTER TABLE [edfi].[StudentCompetencyObjective] ADD StudentCompetencyObjectiveIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentCompetencyObjectiveIdentity on [edfi].[StudentCompetencyObjective] (StudentCompetencyObjectiveIdentity)

ALTER TABLE [edfi].[AssessmentProgram] ADD AssessmentProgramIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentProgramIdentity on [edfi].[AssessmentProgram] (AssessmentProgramIdentity)

ALTER TABLE [edfi].[OpenStaffPositionAcademicSubject] ADD OpenStaffPositionAcademicSubjectIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_OpenStaffPositionAcademicSubjectIdentity on [edfi].[OpenStaffPositionAcademicSubject] (OpenStaffPositionAcademicSubjectIdentity)

ALTER TABLE [edfi].[Intervention] ADD InterventionIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionIdentity on [edfi].[Intervention] (InterventionIdentity)

ALTER TABLE [edfi].[DisciplineActionDiscipline] ADD DisciplineActionDisciplineIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_DisciplineActionDisciplineIdentity on [edfi].[DisciplineActionDiscipline] (DisciplineActionDisciplineIdentity)

ALTER TABLE [edfi].[StudentCTEProgramAssociation] ADD StudentCTEProgramAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentCTEProgramAssociationIdentity on [edfi].[StudentCTEProgramAssociation] (StudentCTEProgramAssociationIdentity)

ALTER TABLE [edfi].[Section] ADD SectionIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_SectionIdentity on [edfi].[Section] (SectionIdentity)

ALTER TABLE [edfi].[OpenStaffPositionInstructionalGradeLevel] ADD OpenStaffPositionInstructionalGradeLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_OpenStaffPositionInstructionalGradeLevelIdentity on [edfi].[OpenStaffPositionInstructionalGradeLevel] (OpenStaffPositionInstructionalGradeLevelIdentity)

ALTER TABLE [edfi].[InterventionAppropriateGradeLevel] ADD InterventionAppropriateGradeLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionAppropriateGradeLevelIdentity on [edfi].[InterventionAppropriateGradeLevel] (InterventionAppropriateGradeLevelIdentity)

ALTER TABLE [edfi].[DisciplineActionDisciplineIncident] ADD DisciplineActionDisciplineIncidentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_DisciplineActionDisciplineIncidentIdentity on [edfi].[DisciplineActionDisciplineIncident] (DisciplineActionDisciplineIncidentIdentity)

ALTER TABLE [edfi].[StudentCTEProgramAssociationCTEProgram] ADD StudentCTEProgramAssociationCTEProgramIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentCTEProgramAssociationCTEProgramIdentity on [edfi].[StudentCTEProgramAssociationCTEProgram] (StudentCTEProgramAssociationCTEProgramIdentity)

ALTER TABLE [edfi].[AssessmentScore] ADD AssessmentScoreIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentScoreIdentity on [edfi].[AssessmentScore] (AssessmentScoreIdentity)

ALTER TABLE [edfi].[SectionAttendanceTakenEvent] ADD SectionAttendanceTakenEventIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_SectionAttendanceTakenEventIdentity on [edfi].[SectionAttendanceTakenEvent] (SectionAttendanceTakenEventIdentity)

ALTER TABLE [edfi].[InterventionAppropriateSex] ADD InterventionAppropriateSexIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionAppropriateSexIdentity on [edfi].[InterventionAppropriateSex] (InterventionAppropriateSexIdentity)

ALTER TABLE [edfi].[StudentDisability] ADD StudentDisabilityIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentDisabilityIdentity on [edfi].[StudentDisability] (StudentDisabilityIdentity)

ALTER TABLE [edfi].[AssessmentSection] ADD AssessmentSectionIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_AssessmentSectionIdentity on [edfi].[AssessmentSection] (AssessmentSectionIdentity)

ALTER TABLE [edfi].[SectionCharacteristic] ADD SectionCharacteristicIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_SectionCharacteristicIdentity on [edfi].[SectionCharacteristic] (SectionCharacteristicIdentity)

ALTER TABLE [edfi].[DisciplineActionStaff] ADD DisciplineActionStaffIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_DisciplineActionStaffIdentity on [edfi].[DisciplineActionStaff] (DisciplineActionStaffIdentity)

ALTER TABLE [edfi].[StudentDisciplineIncidentAssociation] ADD StudentDisciplineIncidentAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentDisciplineIncidentAssociationIdentity on [edfi].[StudentDisciplineIncidentAssociation] (StudentDisciplineIncidentAssociationIdentity)

ALTER TABLE [edfi].[Parent] ADD ParentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ParentIdentity on [edfi].[Parent] (ParentIdentity)

ALTER TABLE [edfi].[InterventionDiagnosis] ADD InterventionDiagnosisIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionDiagnosisIdentity on [edfi].[InterventionDiagnosis] (InterventionDiagnosisIdentity)

ALTER TABLE [edfi].[StudentDisciplineIncidentAssociationBehavior] ADD StudentDisciplineIncidentAssociationBehaviorIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentDisciplineIncidentAssociationBehaviorIdentity on [edfi].[StudentDisciplineIncidentAssociationBehavior] (StudentDisciplineIncidentAssociationBehaviorIdentity)

ALTER TABLE [edfi].[ParentAddress] ADD ParentAddressIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ParentAddressIdentity on [edfi].[ParentAddress] (ParentAddressIdentity)

ALTER TABLE [edfi].[InterventionEducationContent] ADD InterventionEducationContentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionEducationContentIdentity on [edfi].[InterventionEducationContent] (InterventionEducationContentIdentity)

ALTER TABLE [edfi].[DisciplineIncident] ADD DisciplineIncidentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_DisciplineIncidentIdentity on [edfi].[DisciplineIncident] (DisciplineIncidentIdentity)

ALTER TABLE [edfi].[StudentEducationOrganizationAssociation] ADD StudentEducationOrganizationAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentEducationOrganizationAssociationIdentity on [edfi].[StudentEducationOrganizationAssociation] (StudentEducationOrganizationAssociationIdentity)

ALTER TABLE [edfi].[SectionProgram] ADD SectionProgramIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_SectionProgramIdentity on [edfi].[SectionProgram] (SectionProgramIdentity)

ALTER TABLE [edfi].[ParentElectronicMail] ADD ParentElectronicMailIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ParentElectronicMailIdentity on [edfi].[ParentElectronicMail] (ParentElectronicMailIdentity)

ALTER TABLE [edfi].[DisciplineIncidentBehavior] ADD DisciplineIncidentBehaviorIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_DisciplineIncidentBehaviorIdentity on [edfi].[DisciplineIncidentBehavior] (DisciplineIncidentBehaviorIdentity)

ALTER TABLE [edfi].[StudentElectronicMail] ADD StudentElectronicMailIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentElectronicMailIdentity on [edfi].[StudentElectronicMail] (StudentElectronicMailIdentity)

ALTER TABLE [edfi].[ParentIdentificationDocument] ADD ParentIdentificationDocumentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ParentIdentificationDocumentIdentity on [edfi].[ParentIdentificationDocument] (ParentIdentificationDocumentIdentity)

ALTER TABLE [edfi].[InterventionInterventionPrescription] ADD InterventionInterventionPrescriptionIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionInterventionPrescriptionIdentity on [edfi].[InterventionInterventionPrescription] (InterventionInterventionPrescriptionIdentity)

ALTER TABLE [edfi].[DisciplineIncidentWeapon] ADD DisciplineIncidentWeaponIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_DisciplineIncidentWeaponIdentity on [edfi].[DisciplineIncidentWeapon] (DisciplineIncidentWeaponIdentity)

ALTER TABLE [edfi].[StudentGradebookEntry] ADD StudentGradebookEntryIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentGradebookEntryIdentity on [edfi].[StudentGradebookEntry] (StudentGradebookEntryIdentity)

ALTER TABLE [edfi].[BellSchedule] ADD BellScheduleIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_BellScheduleIdentity on [edfi].[BellSchedule] (BellScheduleIdentity)

ALTER TABLE [edfi].[ParentInternationalAddress] ADD ParentInternationalAddressIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ParentInternationalAddressIdentity on [edfi].[ParentInternationalAddress] (ParentInternationalAddressIdentity)

ALTER TABLE [edfi].[InterventionLearningResourceMetadataURI] ADD InterventionLearningResourceMetadataURIIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionLearningResourceMetadataURIIdentity on [edfi].[InterventionLearningResourceMetadataURI] (InterventionLearningResourceMetadataURIIdentity)

ALTER TABLE [edfi].[StudentIdentificationCode] ADD StudentIdentificationCodeIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentIdentificationCodeIdentity on [edfi].[StudentIdentificationCode] (StudentIdentificationCodeIdentity)

ALTER TABLE [edfi].[BellScheduleMeetingTime] ADD BellScheduleMeetingTimeIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_BellScheduleMeetingTimeIdentity on [edfi].[BellScheduleMeetingTime] (BellScheduleMeetingTimeIdentity)

ALTER TABLE [edfi].[ParentOtherName] ADD ParentOtherNameIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ParentOtherNameIdentity on [edfi].[ParentOtherName] (ParentOtherNameIdentity)

ALTER TABLE [edfi].[InterventionMeetingTime] ADD InterventionMeetingTimeIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionMeetingTimeIdentity on [edfi].[InterventionMeetingTime] (InterventionMeetingTimeIdentity)

ALTER TABLE [edfi].[StudentIdentificationDocument] ADD StudentIdentificationDocumentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentIdentificationDocumentIdentity on [edfi].[StudentIdentificationDocument] (StudentIdentificationDocumentIdentity)

ALTER TABLE [edfi].[Budget] ADD BudgetIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_BudgetIdentity on [edfi].[Budget] (BudgetIdentity)

ALTER TABLE [edfi].[ParentTelephone] ADD ParentTelephoneIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ParentTelephoneIdentity on [edfi].[ParentTelephone] (ParentTelephoneIdentity)

ALTER TABLE [edfi].[InterventionPopulationServed] ADD InterventionPopulationServedIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionPopulationServedIdentity on [edfi].[InterventionPopulationServed] (InterventionPopulationServedIdentity)

ALTER TABLE [edfi].[CalendarDate] ADD CalendarDateIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CalendarDateIdentity on [edfi].[CalendarDate] (CalendarDateIdentity)

ALTER TABLE [edfi].[Session] ADD SessionIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_SessionIdentity on [edfi].[Session] (SessionIdentity)

ALTER TABLE [edfi].[Payroll] ADD PayrollIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_PayrollIdentity on [edfi].[Payroll] (PayrollIdentity)

ALTER TABLE [edfi].[InterventionPrescription] ADD InterventionPrescriptionIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionPrescriptionIdentity on [edfi].[InterventionPrescription] (InterventionPrescriptionIdentity)

ALTER TABLE [edfi].[EducationContent] ADD EducationContentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationContentIdentity on [edfi].[EducationContent] (EducationContentIdentity)

ALTER TABLE [edfi].[StudentIndicator] ADD StudentIndicatorIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentIndicatorIdentity on [edfi].[StudentIndicator] (StudentIndicatorIdentity)

ALTER TABLE [edfi].[CalendarDateCalendarEvent] ADD CalendarDateCalendarEventIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CalendarDateCalendarEventIdentity on [edfi].[CalendarDateCalendarEvent] (CalendarDateCalendarEventIdentity)

ALTER TABLE [edfi].[SessionAcademicWeek] ADD SessionAcademicWeekIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_SessionAcademicWeekIdentity on [edfi].[SessionAcademicWeek] (SessionAcademicWeekIdentity)

ALTER TABLE [edfi].[InterventionPrescriptionAppropriateGradeLevel] ADD InterventionPrescriptionAppropriateGradeLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionPrescriptionAppropriateGradeLevelIdentity on [edfi].[InterventionPrescriptionAppropriateGradeLevel] (InterventionPrescriptionAppropriateGradeLevelIdentity)

ALTER TABLE [edfi].[EducationContentAppropriateGradeLevel] ADD EducationContentAppropriateGradeLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationContentAppropriateGradeLevelIdentity on [edfi].[EducationContentAppropriateGradeLevel] (EducationContentAppropriateGradeLevelIdentity)

ALTER TABLE [edfi].[StudentInternationalAddress] ADD StudentInternationalAddressIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentInternationalAddressIdentity on [edfi].[StudentInternationalAddress] (StudentInternationalAddressIdentity)

ALTER TABLE [edfi].[SessionGradingPeriod] ADD SessionGradingPeriodIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_SessionGradingPeriodIdentity on [edfi].[SessionGradingPeriod] (SessionGradingPeriodIdentity)

ALTER TABLE [edfi].[InterventionPrescriptionAppropriateSex] ADD InterventionPrescriptionAppropriateSexIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionPrescriptionAppropriateSexIdentity on [edfi].[InterventionPrescriptionAppropriateSex] (InterventionPrescriptionAppropriateSexIdentity)

ALTER TABLE [edfi].[EducationContentAppropriateSex] ADD EducationContentAppropriateSexIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationContentAppropriateSexIdentity on [edfi].[EducationContentAppropriateSex] (EducationContentAppropriateSexIdentity)

ALTER TABLE [edfi].[StudentInterventionAssociation] ADD StudentInterventionAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentInterventionAssociationIdentity on [edfi].[StudentInterventionAssociation] (StudentInterventionAssociationIdentity)

ALTER TABLE [edfi].[InterventionPrescriptionDiagnosis] ADD InterventionPrescriptionDiagnosisIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionPrescriptionDiagnosisIdentity on [edfi].[InterventionPrescriptionDiagnosis] (InterventionPrescriptionDiagnosisIdentity)

ALTER TABLE [edfi].[EducationContentAuthor] ADD EducationContentAuthorIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationContentAuthorIdentity on [edfi].[EducationContentAuthor] (EducationContentAuthorIdentity)

ALTER TABLE [edfi].[StudentInterventionAssociationInterventionEffectiveness] ADD StudentInterventionAssociationInterventionEffectivenessIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentInterventionAssociationInterventionEffectivenessIdentity on [edfi].[StudentInterventionAssociationInterventionEffectiveness] (StudentInterventionAssociationInterventionEffectivenessIdentity)

ALTER TABLE [edfi].[InterventionPrescriptionEducationContent] ADD InterventionPrescriptionEducationContentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionPrescriptionEducationContentIdentity on [edfi].[InterventionPrescriptionEducationContent] (InterventionPrescriptionEducationContentIdentity)

ALTER TABLE [edfi].[EducationContentDerivativeSourceEducationContent] ADD EducationContentDerivativeSourceEducationContentIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationContentDerivativeSourceEducationContentIdentity on [edfi].[EducationContentDerivativeSourceEducationContent] (EducationContentDerivativeSourceEducationContentIdentity)

ALTER TABLE [edfi].[StudentInterventionAttendanceEvent] ADD StudentInterventionAttendanceEventIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentInterventionAttendanceEventIdentity on [edfi].[StudentInterventionAttendanceEvent] (StudentInterventionAttendanceEventIdentity)

ALTER TABLE [edfi].[InterventionPrescriptionLearningResourceMetadataURI] ADD InterventionPrescriptionLearningResourceMetadataURIIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionPrescriptionLearningResourceMetadataURIIdentity on [edfi].[InterventionPrescriptionLearningResourceMetadataURI] (InterventionPrescriptionLearningResourceMetadataURIIdentity)

ALTER TABLE [edfi].[EducationContentDerivativeSourceLearningResourceMetadataURI] ADD EducationContentDerivativeSourceLearningResourceMetadataURIIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationContentDerivativeSourceLearningResourceMetadataURIIdentity on [edfi].[EducationContentDerivativeSourceLearningResourceMetadataURI] (EducationContentDerivativeSourceLearningResourceMetadataURIIdentity)

ALTER TABLE [edfi].[StudentLanguage] ADD StudentLanguageIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentLanguageIdentity on [edfi].[StudentLanguage] (StudentLanguageIdentity)

ALTER TABLE [edfi].[PostSecondaryEvent] ADD PostSecondaryEventIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_PostSecondaryEventIdentity on [edfi].[PostSecondaryEvent] (PostSecondaryEventIdentity)

ALTER TABLE [edfi].[InterventionPrescriptionPopulationServed] ADD InterventionPrescriptionPopulationServedIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionPrescriptionPopulationServedIdentity on [edfi].[InterventionPrescriptionPopulationServed] (InterventionPrescriptionPopulationServedIdentity)

ALTER TABLE [edfi].[EducationContentDerivativeSourceURI] ADD EducationContentDerivativeSourceURIIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationContentDerivativeSourceURIIdentity on [edfi].[EducationContentDerivativeSourceURI] (EducationContentDerivativeSourceURIIdentity)

ALTER TABLE [edfi].[StudentLanguageUse] ADD StudentLanguageUseIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentLanguageUseIdentity on [edfi].[StudentLanguageUse] (StudentLanguageUseIdentity)

ALTER TABLE [edfi].[ClassPeriod] ADD ClassPeriodIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_ClassPeriodIdentity on [edfi].[ClassPeriod] (ClassPeriodIdentity)

ALTER TABLE [edfi].[StaffAddress] ADD StaffAddressIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffAddressIdentity on [edfi].[StaffAddress] (StaffAddressIdentity)

ALTER TABLE [edfi].[InterventionPrescriptionURI] ADD InterventionPrescriptionURIIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionPrescriptionURIIdentity on [edfi].[InterventionPrescriptionURI] (InterventionPrescriptionURIIdentity)

ALTER TABLE [edfi].[EducationContentLanguage] ADD EducationContentLanguageIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationContentLanguageIdentity on [edfi].[EducationContentLanguage] (EducationContentLanguageIdentity)

ALTER TABLE [edfi].[StudentLearningObjective] ADD StudentLearningObjectiveIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentLearningObjectiveIdentity on [edfi].[StudentLearningObjective] (StudentLearningObjectiveIdentity)

ALTER TABLE [edfi].[PostSecondaryEventPostSecondaryInstitution] ADD PostSecondaryEventPostSecondaryInstitutionIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_PostSecondaryEventPostSecondaryInstitutionIdentity on [edfi].[PostSecondaryEventPostSecondaryInstitution] (PostSecondaryEventPostSecondaryInstitutionIdentity)

ALTER TABLE [edfi].[InterventionStaff] ADD InterventionStaffIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionStaffIdentity on [edfi].[InterventionStaff] (InterventionStaffIdentity)

ALTER TABLE [edfi].[EducationOrganization] ADD EducationOrganizationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationOrganizationIdentity on [edfi].[EducationOrganization] (EducationOrganizationIdentity)

ALTER TABLE [edfi].[StudentLearningStyle] ADD StudentLearningStyleIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentLearningStyleIdentity on [edfi].[StudentLearningStyle] (StudentLearningStyleIdentity)

ALTER TABLE [edfi].[PostSecondaryEventPostSecondaryInstitutionIdentificationCode] ADD PostSecondaryEventPostSecondaryInstitutionIdentificationCodeIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_PostSecondaryEventPostSecondaryInstitutionIdentificationCodeIdentity on [edfi].[PostSecondaryEventPostSecondaryInstitutionIdentificationCode] (PostSecondaryEventPostSecondaryInstitutionIdentificationCodeIdentity)

ALTER TABLE [edfi].[InterventionStudy] ADD InterventionStudyIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionStudyIdentity on [edfi].[InterventionStudy] (InterventionStudyIdentity)

ALTER TABLE [edfi].[EducationOrganizationAddress] ADD EducationOrganizationAddressIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationOrganizationAddressIdentity on [edfi].[EducationOrganizationAddress] (EducationOrganizationAddressIdentity)

ALTER TABLE [edfi].[StudentMigrantEducationProgramAssociation] ADD StudentMigrantEducationProgramAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StudentMigrantEducationProgramAssociationIdentity on [edfi].[StudentMigrantEducationProgramAssociation] (StudentMigrantEducationProgramAssociationIdentity)

ALTER TABLE [edfi].[Cohort] ADD CohortIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_CohortIdentity on [edfi].[Cohort] (CohortIdentity)

ALTER TABLE [edfi].[StaffCohortAssociation] ADD StaffCohortAssociationIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_StaffCohortAssociationIdentity on [edfi].[StaffCohortAssociation] (StaffCohortAssociationIdentity)

ALTER TABLE [edfi].[PostSecondaryEventPostSecondaryInstitutionMediumOfInstruction] ADD PostSecondaryEventPostSecondaryInstitutionMediumOfInstructionIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_PostSecondaryEventPostSecondaryInstitutionMediumOfInstructionIdentity on [edfi].[PostSecondaryEventPostSecondaryInstitutionMediumOfInstruction] (PostSecondaryEventPostSecondaryInstitutionMediumOfInstructionIdentity)

ALTER TABLE [edfi].[InterventionStudyAppropriateGradeLevel] ADD InterventionStudyAppropriateGradeLevelIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_InterventionStudyAppropriateGradeLevelIdentity on [edfi].[InterventionStudyAppropriateGradeLevel] (InterventionStudyAppropriateGradeLevelIdentity)

ALTER TABLE [edfi].[EducationOrganizationCategory] ADD EducationOrganizationCategoryIdentity int IDENTITY(1,1) NOT NULL
CREATE UNIQUE INDEX IX_EducationOrganizationCategoryIdentity on [edfi].[EducationOrganizationCategory] (EducationOrganizationCategoryIdentity)

