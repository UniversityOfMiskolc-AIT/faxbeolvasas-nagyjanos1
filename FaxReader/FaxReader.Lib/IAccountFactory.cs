namespace FaxReader.Lib
{
    /// <summary>
    /// Számlákat előállító osztály. Csak egy darab számlát elő.
    /// </summary>
    public interface IAccountFactory
    {
        /// <summary>
        /// A számla (fax formátumú) nyers sorait átalakítja egy 3*27-es mátrixá.
        /// </summary>
        /// <param name="rows">A számla nyers sorai string tömbben reprezentálva.</param>
        /// <returns>Egy számlaobjektum.</returns>
        Account Create(params string[] rows);

        /// <summary>
        /// A számla alfanumerikus karektereiből, mappelési szótárból kiválasztja a megfelelőszámot majd létrehozza a számlaobjektumot.
        /// </summary>
        /// <param name="accountStr">A számla számait reprezentáló string. Alfanumerikus karaktereket tartalmazhat.</param>
        /// <returns>Egy számla objektum.</returns>
        Account Create(string account);
    }
}
