using PasswordStrongVerificator;

namespace PasswordStringVerificator_UnitTests
{
    [TestClass]
    public class PasswordStrongVerificator_UnitTest
    {
        [TestMethod]
        //Test pour vérifier la robustesse globale de mon mot de passe
        public void Password_ShouldBeFaible()
        {
            string faiblePassword = "toto";

            var reponseFaible = PasswordVerificator.Evalue(faiblePassword);
            Assert.AreEqual(Robustesse.faible, reponseFaible);

        }

        [TestMethod]
        public void Password_ShouldBeFaibleWithOnlyMinAlpha()
        {
            string moyenPassword = "toto123456";

            var reponseMoyen = PasswordVerificator.Evalue(moyenPassword);
            Assert.AreEqual(Robustesse.faible, reponseMoyen);
        }

        [TestMethod]
        public void Password_ShouldBeMoyen()
        {
            string moyenPassword = "Toto123456";

            var reponseMoyen = PasswordVerificator.Evalue(moyenPassword);
            Assert.AreEqual(Robustesse.moyen, reponseMoyen);
        }

        [TestMethod]
        public void Password_ShouldBeFort()
        {
            string fortPassword = "@fdsfd$6546JHYHGd";

            var reponseFort = PasswordVerificator.Evalue(fortPassword);
            Assert.AreEqual(Robustesse.fort, reponseFort);
        }
    }
}