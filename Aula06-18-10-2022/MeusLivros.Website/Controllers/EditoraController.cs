using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Repositories;
using MeusLivros.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MeusLivros.Website.Controllers;

public class EditoraController : Controller
{
    private readonly IEditoraRepository _editoraRepository;

    public EditoraController(IEditoraRepository editoraRepository)
    {
        _editoraRepository = editoraRepository;
    }

    public IActionResult Index()
    {
        var editoras = _editoraRepository.BuscarTodos();

        return View(editoras);
    }

    public IActionResult Cadastro(int? id)
    {
        if (id == null)
            return View();

        var editora = _editoraRepository.BuscarPorId(id ?? 0);
        if (editora == null)
            return View();

        return View(new EditoraViewModel {
            Id = editora.Id,
            Nome = editora.Nome
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastro(EditoraViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (model.Id > 0)
            _editoraRepository.Alterar(new Editora(model.Id ?? 0, model.Nome));
        else
            _editoraRepository.Inserir(new Editora(model.Nome));

        return RedirectToAction("Index");
    }

    public IActionResult Excluir(int id)
    {
        _editoraRepository.Excluir(new Editora(id, ""));

        return RedirectToAction("Index");
    }
}