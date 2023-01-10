module grpc.api.comment.service

open System.Threading.Tasks
open Grpc.Core

open grpc_code_gen.comment
open grpc.api.comment
open fsharper.op
open fsharper.typ

type Ctx = ServerCallContext

type CommentService() =
    inherit grpc_code_gen.comment.CommentService.CommentServiceBase()

    override self.Get(req: get.Req, ctx: Ctx) =
        grpc.api.comment.get.handler req ctx |> unwrapOr
        <| fun msg -> grpc_code_gen.comment.get.Rsp(Ok = false, Msg = msg)
        |> Task.FromResult

    override self.GetAll(req: get_all.Req, ctx: Ctx) =
        getAll.handler req ctx |> unwrapOr
        <| fun msg -> get_all.Rsp()
        |> Task.FromResult

    override self.GetAllSha256(req: get_all_sha256.Req, ctx: Ctx) =
        getAllSha256.handler req ctx |> unwrapOr
        <| fun msg -> get_all_sha256.Rsp()
        |> Task.FromResult

    override self.Create(req: create.Req, ctx: Ctx) =
        create.handler req ctx |> unwrapOr
        <| fun msg -> create.Rsp(Ok = false, Msg = msg)
        |> Task.FromResult

    override self.Update(req: update.Req, ctx: Ctx) =
        update.handler req ctx |> unwrapOr
        <| fun msg -> update.Rsp(Ok = false, Msg = msg)
        |> Task.FromResult

    override self.Delete(req: delete.Req, ctx: Ctx) =
        delete.handler req ctx |> unwrapOr
        <| fun msg -> delete.Rsp(Ok = false, Msg = msg)
        |> Task.FromResult